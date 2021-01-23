    public static readonly DependencyProperty IsItemVisibleProperty = DependencyProperty.Register("IsItemVisible", typeof(Visibility), typeof(MainWindow), new FrameworkPropertyMetadata(Visibility.Visible));
    
    public Visibility IsItemVisible
    {
    	get
    	{
    		return (Visibility)GetValue(IsItemVisibleProperty);
    	}
    	set
    	{
    		SetValue(IsItemVisibleProperty, value);
    	}
    }
