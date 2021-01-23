    public static readonly DependencyProperty ThicknessProperty =
        DependencyProperty.Register(
            "Thickness", typeof(double), typeof(CustomCanvas),
            new FrameworkPropertyMetadata(
                0, FrameworkPropertyMetadataOptions.AffectsRender));
    public double Thickness
    {
        get { return (double)GetValue(ThicknessProperty); }
        set { SetValue(ThicknessProperty, value); }
    }
