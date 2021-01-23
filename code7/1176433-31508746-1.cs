    public IEnumerable<string> Oz
	{
		get { return (IEnumerable<string>)GetValue(OzProperty); }
		set { SetValue(OzProperty, value); }
	}
		
	public static readonly DependencyProperty OzProperty = DependencyProperty.Register("Oz", typeof(IEnumerable<string>), typeof(MainWindow), new PropertyMetadata(null));	
