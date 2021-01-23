    public static class PasswordHelper
    {
        public static readonly DependencyProperty DesignPasswordProperty =
            DependencyProperty.RegisterAttached("DesignPassword",
            typeof(string), typeof(PasswordHelper),
            new FrameworkPropertyMetadata(string.Empty, OnDesignPasswordPropertyChanged));
    
        public static void SetDesignPassword(DependencyObject dp, string value)
        {
            dp.SetValue(DesignPasswordProperty, value);
        }
    
        public static string GetDesignPassword(DependencyObject dp)
        {
            return (string)dp.GetValue(DesignPasswordProperty);
        }
    
        private static void OnDesignPasswordPropertyChanged(DependencyObject sender, 
            DependencyPropertyChangedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(sender))
            {
                var passwordBox = (PasswordBox)sender;
                passwordBox.Password = (string)e.NewValue;               
            }            
        }
    }
