    public static readonly DependencyProperty IsActiveProperty =
            DependencyProperty.Register("IsActive", typeof(bool), typeof(RubberBandBehavior),
            new PropertyMetadata(IsActiveProperty_Changed));
    
    public bool IsActive
    {
    	get { return (bool)GetValue(IsActiveProperty); }
    	set { SetValue(IsActiveProperty, value); }
    }
