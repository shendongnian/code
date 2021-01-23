    private async void SaveCroppedImage(object sender, RoutedEventArgs e)
           {
               StorageFile file = await KnownFolders.CameraRoll.CreateFileAsync("edited.jpg", CreationCollisionOption.ReplaceExisting);
               using (IRandomAccessStream stream =await file.OpenAsync(FileAccessMode.ReadWrite))
               {
                   await EncodeWriteableBitmap(WB_CroppedImage, stream, BitmapEncoder.JpegEncoderId);
               }
                  
           }
           private static async Task EncodeWriteableBitmap(WriteableBitmap bmp, IRandomAccessStream writeStream, Guid encoderId)
           {
               // Copy buffer to pixels
               byte[] pixels;
               using (var stream = bmp.PixelBuffer.AsStream())
               {
                   pixels = new byte[(uint)stream.Length];
                   await stream.ReadAsync(pixels, 0, pixels.Length);
               }
               // Encode pixels into stream
               var encoder = await BitmapEncoder.CreateAsync(encoderId, writeStream);
               encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Premultiplied,
                  (uint)bmp.PixelWidth, (uint)bmp.PixelHeight,
                  96, 96, pixels);
               await encoder.FlushAsync();
           }
