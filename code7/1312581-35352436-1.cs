    private async Task TakePhoto()
            {
                _mediaCapture.VideoDeviceController.FlashControl.Auto = false;
                _mediaCapture.VideoDeviceController.FlashControl.Enabled = ((CameraViewModel) this.DataContext).FlashEnable;
                if (_mediaCapture.VideoDeviceController.FocusControl.Supported)
                {
                    await _mediaCapture.VideoDeviceController.FocusControl.FocusAsync();
                }
    
                if (_mediaCapture.VideoDeviceController.TorchControl.Supported)
                {
                    _mediaCapture.VideoDeviceController.TorchControl.Enabled = true;
                }
    
                ImageEncodingProperties imageEncodingProperties = ImageEncodingProperties.CreateJpeg();
                Guid guid = Guid.NewGuid();
                StorageFile cardStorageFile = await ApplicationData.Current.LocalFolder.CreateFileAsync("cardStorageFile" + guid.ToString() + ".jpg", CreationCollisionOption.ReplaceExisting);
    
                using (var imageStream = new InMemoryRandomAccessStream())
                {
                    await _mediaCapture.CapturePhotoToStreamAsync(imageEncodingProperties, imageStream);
    
                    BitmapDecoder dec = await BitmapDecoder.CreateAsync(imageStream);
                    BitmapEncoder enc = await BitmapEncoder.CreateForTranscodingAsync(imageStream, dec);
    
                    enc.BitmapTransform.Rotation = BitmapRotation.Clockwise90Degrees;
    
                    await enc.FlushAsync();
    
                    
                    using (var fileStream = await cardStorageFile.OpenStreamForWriteAsync())
                    {
                        try
                        {
                            await RandomAccessStream.CopyAsync(imageStream, fileStream.AsOutputStream());
                        }
                        catch(Exception ex)
                        {
                            Debug.WriteLine(ex.Message);
                        }
                    }
                }
    
                using (var randomAccessStream = await cardStorageFile.OpenAsync(FileAccessMode.ReadWrite))
                {
                    if (((CameraViewModel) this.DataContext).CardBitmapImage == null)
                    {
                        VideoEncodingProperties photoSizeEncodingProperties = _mediaCapture.VideoDeviceController.GetMediaStreamProperties(MediaStreamType.Photo) as VideoEncodingProperties;
                        
                        if (photoSizeEncodingProperties != null)
                        {
                            ((CameraViewModel) this.DataContext).CardBitmapImage = new WriteableBitmap((int) photoSizeEncodingProperties.Width, (int) photoSizeEncodingProperties.Height);
                        }
                    }
                    await ((CameraViewModel)this.DataContext).CardBitmapImage.SetSourceAsync(randomAccessStream);
                }
    
                ((CameraViewModel) this.DataContext).StorageFileImage = cardStorageFile;
    
                ((CameraViewModel)this.DataContext).CaptureEnable = false;
                ((CameraViewModel)this.DataContext).IsBusy = false;
            }
