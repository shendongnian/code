    private static BitmapImage CreateBitmap(string path)
    {
        var bi = new BitmapImage();
        bi.BeginInit();
        bi.UriSource = new Uri(path);
        bi.EndInit();
        return bi;
    }
    private BitmapImage ScaleImage(BitmapImage original, double scale)
    {
        var scaledBitmapSource = new TransformedBitmap();
        scaledBitmapSource.BeginInit();
        scaledBitmapSource.Source = original;
        scaledBitmapSource.Transform = new ScaleTransform(scale, scale);
        scaledBitmapSource.EndInit();
        return BitmapSourceToBitmap(scaledBitmapSource);
    }
    private BitmapImage CropImage(BitmapImage original, int width, int height)
    {
        var deltaWidth = original.PixelWidth - width;
        var deltaHeight = original.PixelHeight - height;
        var marginX = deltaWidth/2;
        var marginY = deltaHeight/2;
        var rectangle = new Int32Rect(marginX, marginY, width, height);
        var croppedBitmap = new CroppedBitmap(original, rectangle);
        return BitmapSourceToBitmap(croppedBitmap);
    }
    private BitmapImage BitmapSourceToBitmap(BitmapSource source)
    {
        var encoder = new PngBitmapEncoder();
        var memoryStream = new MemoryStream();
        var image = new BitmapImage();
        encoder.Frames.Add(BitmapFrame.Create(source));
        encoder.Save(memoryStream);
        image.BeginInit();
        image.StreamSource = new MemoryStream(memoryStream.ToArray());
        image.EndInit();
        memoryStream.Close();
        return image;
    }
