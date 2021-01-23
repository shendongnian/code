    private async void TakePicture()
        {
            var stream = new InMemoryRandomAccessStream();
            try
            {
                await _mediaCapture.CapturePhotoToStreamAsync(ImageEncodingProperties.CreateJpeg(), stream);
                var photoOrientation = _foundFrontCam ? PhotoOrientation.Rotate90 : PhotoOrientation.Normal;
                var photoFile = await KnownFolders.PicturesLibrary.CreateFileAsync("Photo.jpeg", CreationCollisionOption.GenerateUniqueName);
                await ReencodeAndSavePhotoAsync(stream, photoOrientation, photoFile);                
                var imageBytes = await ShowPhotoOnScreenThenDeleteAsync(photoFile);
                PostToServerAsync(imageBytes);
            }
            catch (Exception ex)
            {
                new MessageDialog(ex.Message).ShowAsync();
            }
        }
    private async Task ReencodeAndSavePhotoAsync(IRandomAccessStream stream, PhotoOrientation photoOrientation, StorageFile photoFile)
        {
            using (var inputStream = stream)
            {
                var decoder = await BitmapDecoder.CreateAsync(inputStream);
                using (var outputStream = await photoFile.OpenAsync(FileAccessMode.ReadWrite))
                {
                    var encoder = await BitmapEncoder.CreateForTranscodingAsync(outputStream, decoder);
                    var properties = new BitmapPropertySet { { "System.Photo.Orientation", new BitmapTypedValue(photoOrientation, PropertyType.UInt16) } };
                    await encoder.BitmapProperties.SetPropertiesAsync(properties);
                    await encoder.FlushAsync();
                }
            }
        }
