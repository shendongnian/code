    public static class AttachedProperty
    {
        public static readonly DependencyProperty DynamicResourceProperty = DependencyProperty.RegisterAttached("DynamicResource", typeof(object), typeof(AttachedProperty), new PropertyMetadata(null));
        public static object GetDynamicResource(DependencyObject obj)
        {
            return (object)obj.GetValue(DynamicResourceProperty);
        }
        public static void SetDynamicResource(DependencyObject obj, object value)
        {
            obj.SetValue(DynamicResourceProperty, value);
        }
    }
