    public static void SetAppBackground(string imageName)
    {
        var imageBrush = new ImageBrush
        {
            ImageSource = new BitmapImage(new Uri(imageName, UriKind.Relative))
        };
        App.RootFrame.Background = imageBrush;
    }
