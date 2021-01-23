    using(BitmapImage image = new BitmapImage())
    {
        image.BeginInit();
        // image.CreateOptions = BitmapCreateOptions.n;
        image.CacheOption = BitmapCacheOption.OnLoad;
        image.UriSource = new Uri(path);
        image.EndInit();
        bitmap = image.Clone();
    }
