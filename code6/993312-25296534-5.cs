    public static readonly DependencyProperty ThicknessProperty =
        DependencyProperty.Register(
            "Thickness", typeof(double), typeof(CustomCanvas),
            new FrameworkPropertyMetadata(
                default(double), FrameworkPropertyMetadataOptions.AffectsRender));
    public double Thickness
    {
        get { return (double)GetValue(ThicknessProperty); }
        set { SetValue(ThicknessProperty, value); }
    }
