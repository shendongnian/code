    public static bool GetIsActive(DependencyObject obj)
    {
    	return (bool)obj.GetValue(IsActiveProperty);
    }
    public static void SetIsActive(DependencyObject obj, bool value)
    {
    	obj.SetValue(IsActiveProperty, value);
    }
    public static readonly DependencyProperty IsActiveProperty =
    	DependencyProperty.RegisterAttached("IsActive", typeof(bool), typeof(RubberBandBehavior), new PropertyMetadata(IsActiveProperty_Changed));
