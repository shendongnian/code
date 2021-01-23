	public static readonly DependencyProperty IsButtonEnabledProperty = 
        DependencyProperty.Register("IsButtonEnabled", typeof(bool), 
        typeof(usrctrl_Camera_Control),new FrameworkPropertyMetadata(false));
	public bool IsButtonEnabled
	{
		get { return (bool)GetValue(usrctrl_Camera_Control.IsButtonEnabledProperty); }
		set { SetValue(usrctrl_Camera_Control.IsButtonEnabledProperty, value); }
	}
	
