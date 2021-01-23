    public static object GetHorizontalOffset(DependencyObject obj)
        {
            return (string)obj.GetValue(HorizontalOffsetProperty);
        }
        public static void SetHorizontalOffset(DependencyObject obj, object value)
        {
            obj.SetValue(HorizontalOffsetProperty, value);
        }
