    /// <summary>
    /// Gets the BitmapSource from the source and closes the file usage.
    /// </summary>
    /// <param name="fileSource">The file to open.</param>
    /// <param name="size">The maximum height of the image.</param>
    /// <returns>The open BitmapSource.</returns>
    public static BitmapSource SourceFrom(this string fileSource, Int32? size = null)
    {
        using (var stream = new FileStream(fileSource, FileMode.Open))
        {
            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            if (size.HasValue)
                bitmapImage.DecodePixelHeight = size.Value;
            //DpiOf() and ScaledSize() uses the same principles of this extension.
            bitmapImage.StreamSource = stream;
            bitmapImage.EndInit();
            //Just in case you want to load the image in another thread.
            bitmapImage.Freeze();             
            return bitmapImage;
        }
    }
