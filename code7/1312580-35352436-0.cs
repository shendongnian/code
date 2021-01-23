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
                Guid guid = Guid.NewGuid();
                ImageEncodingProperties imageEncodingProperties = ImageEncodingProperties.CreateJpeg();
    
                using (var randomAccessStream = new InMemoryRandomAccessStream())
                {
                    await _mediaCapture.CapturePhotoToStreamAsync(imageEncodingProperties, randomAccessStream);
                    
                    IMediaEncodingProperties _photoSizeEncodingProperties = _mediaCapture.VideoDeviceController.GetMediaStreamProperties(MediaStreamType.Photo);
    
                    ((CameraViewModel)this.DataContext).CardBitmapImage = new WriteableBitmap((int)(_photoSizeEncodingProperties as VideoEncodingProperties).Width, (int)(_photoSizeEncodingProperties as VideoEncodingProperties).Height);
                    randomAccessStream.Seek(0);
                    await ((CameraViewModel)this.DataContext).CardBitmapImage.SetSourceAsync(randomAccessStream);
                }
    
                ((CameraViewModel)this.DataContext).CardBitmapImage = ((CameraViewModel) this.DataContext).CardBitmapImage.Rotate(90);
    
                ((CameraViewModel)this.DataContext).CaptureEnable = false;
                ((CameraViewModel)this.DataContext).IsBusy = false;
            }
