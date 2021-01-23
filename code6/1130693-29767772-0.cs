    public static BitmapSource BitmapFromBase64(string base64String)
    {
        var bytes = Convert.FromBase64String(base64String);
        using (var stream = new MemoryStream(bytes))
        {
            var image = new BitmapImage();
            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.StreamSource = stream;
            image.EndInit();
            return image;
        }
    }
