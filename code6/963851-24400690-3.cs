    private static BitmapImage LoadImage(Stream stream)
    {
        // assumes that the streams position is at the beginning
        // for example if you use a memory stream you might need to point it to 0 first
        var image = new BitmapImage();
        image.BeginInit();
        image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
        image.CacheOption = BitmapCacheOption.OnLoad;
        image.UriSource = null;
        image.StreamSource = stream;
        image.EndInit();
        image.Freeze();
        return image;
    }
