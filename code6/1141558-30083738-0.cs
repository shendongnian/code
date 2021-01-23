	public static readonly DependencyProperty IsNyetEnabledProperty = 
        DependencyProperty.Register("IsNyetEnabled", typeof(double), 
        typeof(MetroWindow),new FrameworkPropertyMetadata(false));
																					
	public bool DCLookupByID
	{
		get { return (bool)GetValue(MetroWindow.IsNyetEnabled); }
		set { SetValue(MetroWindow.IsNyetEnabled, value); }
	}
