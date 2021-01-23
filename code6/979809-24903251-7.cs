    class ScrollProvider : DependencyObject
    {
        public static bool GetScrollIntoView(DependencyObject obj)
        {
            return (bool)obj.GetValue(ScrollIntoViewProperty);
        }
        public static void SetScrollIntoView(DependencyObject obj, bool value)
        {
            obj.SetValue(ScrollIntoViewProperty, value);
        }
        // Using a DependencyProperty as the backing store for ScrollIntoView.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ScrollIntoViewProperty =
            DependencyProperty.RegisterAttached("ScrollIntoView", typeof(bool), typeof(ScrollProvider), new PropertyMetadata(false, OnScrollIntoViewChanged));
        private static void OnScrollIntoViewChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = d as FrameworkElement;
            if ((bool)e.NewValue)
            {
                element.BringIntoView();
                element.Focus();
            }
        }
    }
