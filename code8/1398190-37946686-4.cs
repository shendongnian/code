        public async Task<MediaFile> SelectPicture()
        {
            Setup();
            MediaFile file = null;
            try
            {
                file = await _Mediapicker.SelectPhotoAsync(new CameraMediaStorageOptions
                {
                    DefaultCamera = CameraDevice.Front,
                    MaxPixelDimension = 400
                });
            }
            catch (System.Exception ex)
            {
                Status = ex.Message;
            }
            return file;
        }
