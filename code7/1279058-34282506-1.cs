    private async void pointerEntered(object sender, PointerRoutedEventArgs e)
    {
        StorageFile imgFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets\\1.jpg"));
        using(IRandomAccessStream streamIn = await imgFile.OpenReadAsync())
        {
            //decoder the img
            BitmapDecoder decoder = await BitmapDecoder.CreateAsync(BitmapDecoder.JpegDecoderId, streamIn);
            //get pixel
            PixelDataProvider proved = await decoder.GetPixelDataAsync(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Straight, new BitmapTransform(),
                ExifOrientationMode.IgnoreExifOrientation, ColorManagementMode.DoNotColorManage);
            byte[] srcData = proved.DetachPixelData();
            // GRAYSCALE
            for (int i = 0; i < srcData.Length; i += 4)
            {
                double b = srcData[i]; //B
                double g = srcData[i + 1]; //G
                double r = srcData[i + 2]; //R
                //average
                double v = (r + g + b) / 3d;
                //replace old rgb
                srcData[i] = srcData[i + 1] = srcData[i + 2] = Convert.ToByte(v);
            }
            WriteableBitmap wbimg = new WriteableBitmap((int)decoder.PixelWidth, (int)decoder.PixelHeight);
            srcData.CopyTo(wbimg.PixelBuffer);
            this.headerimg.Source = wbimg;
        }
    }
    private async void pointerExited(object sender, PointerRoutedEventArgs e)
    {
        StorageFile imgFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets\\1.jpg"));
        IRandomAccessStream streamIn = await imgFile.OpenReadAsync();
        BitmapImage bitmap = new BitmapImage();
        bitmap.SetSource(streamIn);
        this.headerimg.Source = bitmap;
    }
