    using System;
    using System.IO;
    using UIKit;
    using Xamarin.Forms;
    using System.Threading.Tasks;
    using Foundation;
    namespace TestUIImage.Services
    {
        public class PicturePickerImplementation : IPicturePicker
        {
            public PicturePickerImplementation()
            {
            }
            TaskCompletionSource<NSUrl> urltaskCompletionSource;
            UIImagePickerController imagePicker;
            public Task<NSUrl> GetNSUrlAsync()
            {
                // Create and define UIImagePickerController
                imagePicker = new UIImagePickerController
                {
                    SourceType = UIImagePickerControllerSourceType.PhotoLibrary,
                    MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary)
                };
                // Set event handlers
                imagePicker.FinishedPickingMedia += GetNSUrl;
                imagePicker.Canceled += OnImagePickerCancelled;
                // Present UIImagePickerController
                UIWindow window = UIApplication.SharedApplication.KeyWindow;
                var viewController = window.RootViewController;
                viewController.PresentModalViewController(imagePicker, true);
                // Return Task object
                urltaskCompletionSource = new TaskCompletionSource<NSUrl>();
                return urltaskCompletionSource.Task;
            }
        
            void GetNSUrl(object sender, UIImagePickerMediaPickedEventArgs args)
            {
                urltaskCompletionSource.SetResult(args.ImageUrl);
                imagePicker.DismissModalViewController(true);
            }
        
            void OnImagePickerCancelled(object sender, EventArgs args)
            {
                taskCompletionSource.SetResult(null);
                imagePicker.DismissModalViewController(true);
            }
        }
    }
