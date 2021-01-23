    private BitmapImage image;
    public ImageSource Image
    {
        get
        {
            if (image == null)
            {
                image = new BitmapImage();
                image.BeginInit();
                image.DecodePixelWidth = 100;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = new Uri(value.ToString());
                image.EndInit();
                image.Freeze(); // here
            }
            return image;
        }
    }
