    public static readonly DependencyProperty pvColorProperty =   DependencyProperty.Register("pvColor", 
			typeof(Color), typeof(MainWindow), 
			new PropertyMetadata(Colors.Black));
	public Color pvColor
	{
		get { return (Color)GetValue(pvColorProperty); }
		set { SetValue(pvColorProperty, value); }
	}
 
