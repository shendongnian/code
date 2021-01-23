    public static readonly DependencyProperty RadiusProperty =
        DependencyProperty.RegisterAttached(
            "Radius", typeof(string),
            typeof(ProgressBar),
            new PropertyMetadata(default(string))
        );
