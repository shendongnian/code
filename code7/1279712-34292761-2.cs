    public static readonly	DependencyProperty				FillProperty = DependencyProperty.Register("Fill",	typeof(Brush),			typeof(VNode), new PropertyMetadata(Brushes.Green));    
    public Brush Fill
    {
        get { return (Brush)GetValue(FillProperty); }
        set { SetValue(FillProperty, value); }
    }
