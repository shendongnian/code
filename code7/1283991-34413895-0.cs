    public static class ScrollSynchronizer
    {
        public static readonly DependencyProperty ScrollGroupProperty =
            DependencyProperty.RegisterAttached(
                "ScrollGroup", typeof(string), typeof(ScrollSynchronizer),
                new PropertyMetadata(OnScrollGroupChanged));
        public static string GetScrollGroup(DependencyObject obj)
        {
            return (string)obj.GetValue(ScrollGroupProperty);
        }
        public static void SetScrollGroup(DependencyObject obj, string value)
        {
            obj.SetValue(ScrollGroupProperty, value);
        }
        private static void OnScrollGroupChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var scrollBar = d as ScrollBar;
            ...
        }
    }
