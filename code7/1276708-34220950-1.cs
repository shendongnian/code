    public static class ScrollViewerExtension
    {
        public static readonly DependencyProperty HorizontalOffsetProperty = DependencyProperty.RegisterAttached("HorizontalOffset", typeof (double), typeof (ScrollViewerExtension),
            new PropertyMetadata(HorizontalOffsetChanged));
        private static void HorizontalOffsetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var scrollViewer = (ScrollViewer) d;
            scrollViewer.ScrollToHorizontalOffset((double)e.NewValue);
        }
        public static void SetHorizontalOffset(DependencyObject element, double value)
        {
            element.SetValue(HorizontalOffsetProperty, value);
        }
        public static double GetHorizontalOffset(DependencyObject element)
        {
            return (double) element.GetValue(HorizontalOffsetProperty);
        }
    }
