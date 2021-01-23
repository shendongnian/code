    if (file != null)
    {
        BitmapImage bmp = new BitmapImage();
        using(var imageStream = await file.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite))
        {
            BitmapDecoder decoder = await BitmapDecoder.CreateAsync(imageStream);
            InMemoryRandomAccessStream ras = new InMemoryRandomAccessStream();
            BitmapEncoder encoder = await BitmapEncoder.CreateForTranscodingAsync(ras, decoder);
    
            encoder.BitmapTransform.InterpolationMode = BitmapInterpolationMode.Fant;
            encoder.BitmapTransform.ScaledHeight = 400;
            encoder.BitmapTransform.ScaledWidth = 400;
                               
            try
            {
                await encoder.FlushAsync();
                bmp.SetSource(ras);
            }
            catch (Exception ex)
            {
                if (ex.HResult.ToString() == "WINCODEC_ERR_INVALIDPARAMETER")
                {
                    InMemoryRandomAccessStream pixelras = new InMemoryRandomAccessStream();
                    BitmapEncoder pixelencoder = await BitmapEncoder.CreateAsync(BitmapEncoder.JpegEncoderId, pixelras)
                    BitmapTransform transform = new BitmapTransform();
                    transform.InterpolationMode = BitmapInterpolationMode.Fant;
                    transform.ScaledHeight = 400;
                    transform.ScaledWidth = 400;
                    var provider = await decoder.GetPixelDataAsync(BitmapPixelFormat.Bgra8,
                        BitmapAlphaMode.Ignore,
                        transform,
                        ExifOrientationMode.RespectExifOrientation,
                        ColorManagementMode.DoNotColorManage);
                    var pixels = provider.DetachPixelData();
                    pixelencoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore, 400,
                        400, decoder.DpiX, decoder.DpiY, pixels);
                    try
                    {
                        await pixelencoder.FlushAsync();
                        bmp.SetSource(pixelras);
                    }
                    catch
                    {
    
                    }
                }
            }                    
            img.Source = bmp;                  
        }
    }
 
