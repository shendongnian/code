    private async void TakePicture_Click(object sender, RoutedEventArgs e)
        {
            var camera = new CameraCaptureUI();
            var image = await camera.CaptureFileAsync(CameraCaptureUIMode.Photo);
            if (image != null)
            {
                var stream = await image.OpenAsync(FileAccessMode.Read);
                var bitmap = new BitmapImage();
                bitmap.SetSource(stream);
                Picture.Source = bitmap;
            }
            else
            {
                (new MessageDialog("Something went wrong")).ShowAsync();                
            }
        }
