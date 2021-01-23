    public class Localization
    {
        public static object GetResource(DependencyObject obj)
        {
            return (object)obj.GetValue(ResourceProperty);
        }
        public static void SetResource(DependencyObject obj, object value)
        {
            obj.SetValue(ResourceProperty, value);
        }
        // Using a DependencyProperty as the backing store for Resource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ResourceProperty =
            DependencyProperty.RegisterAttached("Resource", typeof(object), typeof(Localization), new PropertyMetadata(null, OnResourceChanged));
        private static void OnResourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //check if ResourceReferenceExpression is already registered
            if (d.ReadLocalValue(ResourceProperty).GetType().Name == "ResourceReferenceExpression")
                return;
            var fe = d as FrameworkElement;
            if (fe == null)
                return;
            //register ResourceReferenceExpression - what DynamicResourceExtension outputs in ProvideValue
            fe.SetResourceReference(ResourceProperty, e.NewValue);
        }
    }
