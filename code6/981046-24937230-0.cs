    public static class FreezeBehavior
    {
        public static bool GetIsFrozen(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsFrozenProperty);
        }
        public static void SetIsFrozen(DependencyObject obj, bool value)
        {
            obj.SetValue(IsFrozenProperty, value);
        }
        public static readonly DependencyProperty IsFrozenProperty =
            DependencyProperty.RegisterAttached("IsFrozen", typeof(bool), typeof(FreezeBehavior), new PropertyMetadata(OnIsFrozenChanged));
        private static void OnIsFrozenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue)
            {
                var freezable = d as Freezable;
                if (freezable != null && freezable.CanFreeze)
                    freezable.Freeze();
            }
        }
    }
