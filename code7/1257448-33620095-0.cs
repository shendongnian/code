    public static readonly DependencyProperty ThumbnailSourceProperty =
        DependencyProperty.Register("ThumbnailSource", ...); 
    public ImageSource ThumbnailSource
    {
        get { return (ImageSource)GetValue(ThumbnailSourceProperty); }
        set { SetValue(ThumbnailSourceProperty, value); }
    }
