	public static readonly DependencyProperty IsNyetEnabledProperty = 
        DependencyProperty.Register("IsNyetEnabled", typeof(bool), 
        typeof(MainWindow),new FrameworkPropertyMetadata(false));
																					
	public bool IsNyetEnabled
	{
		get { return (bool)GetValue(MainWindow.IsNyetEnabled); }
		set { SetValue(MainWindow.IsNyetEnabled, value); }
	}
