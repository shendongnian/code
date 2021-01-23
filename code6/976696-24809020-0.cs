    public async Task SaveStreamAsync(IRandomAccessStream streamToSave, StorageFile destination)
    {
        BitmapDecoder bmpDecoder = await BitmapDecoder.CreateAsync(streamToSave);
        PixelDataProvider pixelData = await bmpDecoder.GetPixelDataAsync(BitmapPixelFormat.Rgba8, BitmapAlphaMode.Straight, null, ExifOrientationMode.RespectExifOrientation, ColorManagementMode.DoNotColorManage);
        using (var destFileStream = await destination.OpenAsync(FileAccessMode.ReadWrite))
        {
            BitmapEncoder bmpEncoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, destFileStream);
            uint yourWidthAndOrHeight = 1024;
            bmpEncoder.SetPixelData(BitmapPixelFormat.Rgba8, BitmapAlphaMode.Straight, yourWidthAndOrHeight, yourWidthAndOrHeight, 300, 300, pixelData.DetachPixelData());
            await bmpEncoder.FlushAsync();
        }
    }
