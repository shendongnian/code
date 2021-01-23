	public static readonly DependencyProperty FalseColorProperty = DependencyProperty.Register(
        "FalseColor",
        typeof(Brush),
        typeof(BooleanRectangleView),
        new FrameworkPropertyMetadata(
        	Brush.Red, 
        	FrameworkPropertyMetadataOptions.AffectsRender
    	)
	);
	public Brush FalseColor
	{
	    get { return (Brush)GetValue(FalseColorProperty); }
	    set { SetValue(FalseColorProperty, value); }
	}
