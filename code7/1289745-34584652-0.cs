       private byte[] imageData;
       public byte[] ImageData { get { return imageData; } }
       private byte[] ReadStream(Stream input)
       {
           byte[] buffer = new byte[16*1024];
           using (MemoryStream ms = new MemoryStream())
           {
               int read;
               while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
               {
                   ms.Write(buffer, 0, read);
               }
               return ms.ToArray();
           }
       }
       public async Task SelectPicture()
        {
            Setup ();
    
            ImageSource = null;
    
            try
            {
                var mediaFile = await _Mediapicker.SelectPhotoAsync(new CameraMediaStorageOptions
                    {
                        DefaultCamera = CameraDevice.Front,
                        MaxPixelDimension = 400
                    });
    
                VideoInfo = mediaFile.Path;
                // store the image data in a local variable
                imageData = ReadStream(mediaFile.GetStream());
                ImageSource = ImageSource.FromStream(() => mediaFile.Source);
            }
            catch (System.Exception ex)
            {
                Status = ex.Message;
            }
        }
