    public static readonly DependencyProperty FillBrushProperty =
        DependencyProperty.Register(
            "FillBrush", typeof(Brush), typeof(RectangleFillTest));
    public Brush FillBrush
    {
        get { return (Brush)GetValue(FillBrushProperty); }
        set { SetValue(FillBrushProperty, value); }
    }
