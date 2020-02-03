using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SavingImagesWithFileSystemExample.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public ICommand AddPhotoByCameraCommand { private set; get; }
        public ICommand AddPhotoByLibraryCommand { private set; get; }

        public MainPageViewModel()
        {
            //Camera Command
            AddPhotoByCameraCommand = new Command(
                execute: async () =>
                {
                    Console.WriteLine("AddPhotoFromCameraButtonCommandExecuted");

                    if (!Plugin.Media.CrossMedia.Current.IsCameraAvailable || !Plugin.Media.CrossMedia.Current.IsTakePhotoSupported)
                    {
                        Console.WriteLine("No Camera available"); 
                        return;
                    }

                    //TODO: Store image stream in file system.
                    var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions()
                    {

                    });
                });

            //Library Command
            AddPhotoByLibraryCommand = new Command(
                execute: async () =>
                {
                    Console.WriteLine("AddPhotoFromLibraryButtonCommandExecuted");

                    //TODO: Store image stream in file system.
                    var photo = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions()
                    {

                    });
                });
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
