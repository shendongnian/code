    public static class PasswordBoxExtensions
    {
        public static readonly DependencyProperty IsActiveProperty = 
            DependencyProperty.RegisterAttached(
                "IsActive", typeof(bool), typeof(PasswordBoxExtensions), 
                new FrameworkPropertyMetadata(OnIsActiveChanged));
        private static void OnIsActiveChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var passwordBox = d as PasswordBox;
            if (passwordBox == null) return;
            passwordBox.PasswordChanged -= OnPasswordChanged;
            if ((bool)e.NewValue)
            {
                SetIsPasswordEmpty(passwordBox);
                passwordBox.PasswordChanged += OnPasswordChanged;
            }
        }
        private static void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            SetIsPasswordEmpty((PasswordBox)sender);
        }
        public static void SetIsActive(PasswordBox element, bool value)
        {
            element.SetValue(IsActiveProperty, value);
        }
        public static bool GetIsActive(PasswordBox element)
        {
            return (bool)element.GetValue(IsActiveProperty);
        }
        public static readonly DependencyPropertyKey IsPasswordEmptyPropertyKey = 
            DependencyProperty.RegisterAttachedReadOnly(
                "IsPasswordEmpty", typeof(bool), typeof(PasswordBoxExtensions),
                new FrameworkPropertyMetadata());
        public static readonly DependencyProperty IsPasswordEmptyProperty =
            IsPasswordEmptyPropertyKey.DependencyProperty;
        private static void SetIsPasswordEmpty(PasswordBox element)
        {
            element.SetValue(IsPasswordEmptyPropertyKey, element.SecurePassword.Length == 0);
        }
        public static bool GetIsPasswordEmpty(PasswordBox element)
        {
            return (bool)element.GetValue(IsPasswordEmptyProperty);
        }
    }
