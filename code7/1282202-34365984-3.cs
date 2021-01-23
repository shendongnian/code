    public static async Task SaveBitmapToFileAsync(WriteableBitmap image, userId)
    {
        StorageFolder pictureFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("ProfilePictures",CreationCollisionOption.OpenIfExists);
        var file = await pictureFolder.CreateFileAsync(userId + ".jpg", CreationCollisionOption.ReplaceExisting);
        using (var stream = await file.OpenStreamForWriteAsync())
        {
            BitmapEncoder encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.JpegEncoderId, stream.AsRandomAccessStream());
            var pixelStream = bmp.PixelBuffer.AsStream();
            byte[] pixels = new byte[bmp.PixelBuffer.Length];
            await pixelStream.ReadAsync(pixels, 0, pixels.Length);
            encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore, (uint)bmp.PixelWidth, (uint)bmp.PixelHeight, 96, 96, pixels);
            await encoder.FlushAsync();
        }
    }
