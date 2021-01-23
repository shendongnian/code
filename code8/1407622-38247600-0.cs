    public static class StyleHelper
    {
        public static readonly DependencyProperty StateProperty =
            DependencyProperty.RegisterAttached(
                "State", typeof(bool), typeof(StyleHelper));
        public static bool GetState(DependencyObject obj)
        {
            return (bool)obj.GetValue(StateProperty);
        }
        public static void SetState(DependencyObject obj, bool value)
        {
            obj.SetValue(StateProperty, value);
        }
    }
