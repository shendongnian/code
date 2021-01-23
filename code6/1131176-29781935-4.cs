    public static class AttachedProperties
    {
        public static readonly DependencyProperty ChangeStyleProperty = DependencyProperty.RegisterAttached("ChangeStyle", typeof(bool), typeof(AttachedProperties));
        public static bool GetChangeStyle(DependencyObject d)
        {
            return (bool)d.GetValue(ChangeStyleProperty);
        }
        public static void SetChangeStyle(DependencyObject d, bool value)
        {
            d.SetValue(ChangeStyleProperty, value);
        }
    }
