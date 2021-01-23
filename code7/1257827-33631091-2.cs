    public static class WindowClosingBehavior
    {
            public static bool GetIsClosingInitiated(DependencyObject obj)
            {
                return (bool)obj.GetValue(IsClosingInitiatedProperty);
            }
    
            public static void SetIsClosingInitiated(DependencyObject obj, bool value)
            {
                obj.SetValue(IsClosingInitiatedProperty, value);
            }
    
            public static readonly DependencyProperty IsClosingInitiatedProperty = DependencyProperty.RegisterAttached(
                "IsClosingInitiated", 
                typeof(bool), 
                typeof(WindowClosingBehavior),
                new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, IsClosingInitiatedChanged));
    
            private static void IsClosingInitiatedChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
            {
                var window = target as Window;
                if (window != null && (bool)e.NewValue)
                {
                    window.Close();
                }
            }
    }
