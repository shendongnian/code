    public class FocusHelper : DependencyObject
    {
        #region Attached Properties
        public static readonly DependencyProperty IsFocusedProperty = DependencyProperty.RegisterAttached("IsFocused", typeof(bool), typeof(FocusHelper), new PropertyMetadata(default(bool), OnIsFocusedChanged));
        public static bool GetIsFocused(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsFocusedProperty);
        }
        public static void SetIsFocused(DependencyObject obj, bool value)
        {
            obj.SetValue(IsFocusedProperty, value);
        }
        #endregion
        #region Methods
        public static void OnIsFocusedChanged(DependencyObject s, DependencyPropertyChangedEventArgs e)
        {
            var ctrl = s as Control;
            if (ctrl == null)
            {
                throw new ArgumentException();
            }
            if ((bool)e.NewValue)
            {
                ctrl.Focus(FocusState.Keyboard);
            }
        }
        #endregion
    }
