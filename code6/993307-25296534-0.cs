    public static readonly DependencyProperty ThicknessProperty =
        DependencyProperty.Register(
            "Thickness", typeof(int), typeof(CustomCanvas),
            new FrameworkPropertyMetadata(
                0, FrameworkPropertyMetadataOptions.AffectsRender));
