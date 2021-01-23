    public static class TabPanelHeaderHeight
    {
        private const double InitialValue = -1.0;
        private static readonly DependencyProperty HeaderHeightProperty =
            DependencyProperty.RegisterAttached(name: "HeaderHeight", propertyType: typeof(double), ownerType: typeof(TabPanelHeaderHeight),
            defaultMetadata: new FrameworkPropertyMetadata(defaultValue: InitialValue, flags: FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, propertyChangedCallback: OnHeaderHeightChanged));
        public static double GetHeaderHeight(UIElement element)
        {
            return (double)element.GetValue(HeaderHeightProperty);
        }
        public static void SetHeaderHeight(UIElement element, double value)
        {
            element.SetValue(HeaderHeightProperty,value);
        }
        private static void OnHeaderHeightChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var target = obj as TabControl;
            if (target == null)
                return;
            // we hijack the on value changed event to register our event handler to the value we're really interested in
            // but we want to do this only once, so we check if the value is the (invalid) initial value and change the value afterwards to register the event listener only once.
            if ((double)args.OldValue == InitialValue)
            {
                var tp = target.GetChildOfType<TabPanel>();
                
                tp.SizeChanged += (sender, eventArgs) => { TargetSizeChanged(target,tp); };
                TargetSizeChanged(target,tp);
            }
        }
        private static void TargetSizeChanged(TabControl target, TabPanel tp)
        {
            SetHeaderHeight(target, tp.ActualHeight);
        }
        public static T GetChildOfType<T>(this DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null) return null;
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);
                var result = (child as T) ?? GetChildOfType<T>(child);
                if (result != null) return result;
            }
            return null;
        }
    }
