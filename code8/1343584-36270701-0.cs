    public static class StrangeAttachedProperty {
        public static bool GetAddRunByDefault(DependencyObject obj) {
            return (bool) obj.GetValue(AddRunByDefaultProperty);
        }
        public static void SetAddRunByDefault(DependencyObject obj, bool value) {
            obj.SetValue(AddRunByDefaultProperty, value);
        }
        public static readonly DependencyProperty AddRunByDefaultProperty =
            DependencyProperty.RegisterAttached("AddRunByDefault", typeof (bool), typeof (StrangeAttachedProperty), new PropertyMetadata(AddRunByDefaultChanged));
        private static void AddRunByDefaultChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            var element = d as TextBlock;
            if (element != null) {
                // here is the main point - you can do whatever with your textblock here
                // for example you can check some conditions and not add runs in some cases
                element.Inlines.Add(new Run());
            }
        }
    }
