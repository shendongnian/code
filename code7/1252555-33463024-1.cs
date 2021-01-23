    public static readonly DependencyProperty RadiusProperty =
        DependencyProperty.RegisterAttached(
            "Radius", typeof(string),
            typeof(CustomExtensions),
            new PropertyMetadata(default(string))
        );
