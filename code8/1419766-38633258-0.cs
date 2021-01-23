    if (file != null)
    {
        BitmapImage bmp = new BitmapImage();
        using(var imageStream = await file.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite))
        {
            BitmapDecoder decoder = await BitmapDecoder.CreateAsync(imageStream);
            InMemoryRandomAccessStream pixelras = new InMemoryRandomAccessStream();
            BitmapEncoder pixelencoder = await BitmapEncoder.CreateAsync(BitmapEncoder.JpegEncoderId, pixelras);
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
            }
            catch(Exception ex)
            {
    
            }
            bmp.SetSource(pixelras);
            img.Source = bmp;                  
        }
    }
