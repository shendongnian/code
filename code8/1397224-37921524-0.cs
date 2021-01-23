    string fileName = "Image.jpg";// TextBox
        fileName = Path.GetFileName(fileName);
        Windows.Storage.IStorageFile photo =
            await Windows.Storage.KnownFolders.PicturesLibrary.CreateFileAsync
            (fileName, Windows.Storage.CreationCollisionOption.GenerateUniqueName);
        await mediaCapture.CapturePhotoToStorageFileAsync
            (Windows.Media.MediaProperties.ImageEncodingProperties.CreateJpeg(), photo);
        CaptureBtn.Visibility = Visibility.Collapsed;
        ImageView.Visibility = Visibility.Visible;
        previewElement.Visibility = Visibility.Collapsed;
        UploadBtn.Visibility = Visibility.Visible;
        CancelBtn.Visibility = Visibility.Visible;
    using (Windows.Storage.Streams.IRandomAccessStream fileStream =
                    await photo.OpenAsync(Windows.Storage.FileAccessMode.Read))
                {
                        // Set the image source to the selected bitmap.
                        Windows.UI.Xaml.Media.Imaging.BitmapImage bitmapImages =
                            new Windows.UI.Xaml.Media.Imaging.BitmapImage();
                        bitmapImages.SetSource(fileStream);
                        ImageView.Source = bitmapImages;  
                }
