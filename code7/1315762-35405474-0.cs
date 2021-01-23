        public static class FocusExtension
        {
            public static bool GetFocused(DependencyObject obj)
            {
                return (bool)obj.GetValue(FocusedProperty);
            }
            public static void SetFocused(DependencyObject obj, bool value)
            {
                obj.SetValue(FocusedProperty, value);
            }
            public static readonly DependencyProperty FocusedProperty =
                   DependencyProperty.RegisterAttached("Focused",
                   typeof(bool), typeof(FocusExtension),
                   new UIPropertyMetadata(false, OnFocusedPropertyChanged));
            private static void OnFocusedPropertyChanged(DependencyObject d,
                DependencyPropertyChangedEventArgs e)
            {
                var uiElement = (UIElement)d;
                var toSet = (bool)e.NewValue;
                if (toSet)
                {
                    uiElement.Focus();
                }
            }
        }
