    takePhoto.Clicked += async (sender, args) =>
            {
    
              if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.PhotosSupported)
              {
                DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
                return;
              }
    
              var file = await CrossMedia.Current.TakePhotoAsync(new Media.Plugin.Abstractions.StoreCameraMediaOptions
                {
    
                  Directory = "Sample",
                  Name = "test.jpg"
                });
    
              if (file == null)
                return;
    
              DisplayAlert("File Location", file.Path, "OK");
    
              image.Source = ImageSource.FromStream(() =>
              {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
              }); 
            };
