    Decoders.AddDecoder<GifDecoder>();
    ExtendedImage eAt = new ExtendedImage();
    eAt.UriSource = new Uri(@"/medias/at.gif", UriKind.RelativeOrAbsolute);
    eAt.LoadingCompleted += new EventHandler((ss, ee) =>
    {
        Dispatcher.BeginInvoke(() =>
        {
            Image img = new Image();
            img.Source = eAt.ToBitmap();
            grd.Children.Add(img);
        });
    });
    
    
    
