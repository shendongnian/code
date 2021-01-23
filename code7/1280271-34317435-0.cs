    try
    {
        PixelDataProvider provider = await decoder.GetPixelDataAsync(decoder.BitmapPixelFormat, decoder.BitmapAlphaMode, new BitmapTransform(), ExifOrientationMode.RespectExifOrientation, ColorManagementMode.ColorManageToSRgb);
        byte[] pixelBuffer = provider.DetachPixelData();
    }
    catch(Exception ex)
    {
        Debug.WriteLine(ex);
    }
