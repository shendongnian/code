    public static readonly DependencyProperty ThicknessProperty =
        DependencyProperty.Register(
            "Thickness", typeof(int), typeof(CustomCanvas),
            new FrameworkPropertyMetadata(
                default(int), FrameworkPropertyMetadataOptions.AffectsRender));
