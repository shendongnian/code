    namespace CSharpWPF
    {
        class ScrollViewerExtensions : DependencyObject
        {
            public static bool GetIsHorizontalScrollOnWheelEnabled(DependencyObject obj)
            {
                return (bool)obj.GetValue(IsHorizontalScrollOnWheelEnabledProperty);
            }
            public static void SetIsHorizontalScrollOnWheelEnabled(DependencyObject obj, bool value)
            {
                obj.SetValue(IsHorizontalScrollOnWheelEnabledProperty, value);
            }
            // Using a DependencyProperty as the backing store for IsHorizontalScrollOnWheelEnabled.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty IsHorizontalScrollOnWheelEnabledProperty =
                DependencyProperty.RegisterAttached("IsHorizontalScrollOnWheelEnabled", typeof(bool), typeof(ScrollViewerExtensions), new PropertyMetadata(false, OnIsHorizontalScrollOnWheelEnabledChanged));
            private static void OnIsHorizontalScrollOnWheelEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                ScrollViewer sv = d as ScrollViewer;
                if ((bool)e.NewValue)
                    sv.PreviewMouseWheel += sv_PreviewMouseWheel;
                else
                    sv.PreviewMouseWheel -= sv_PreviewMouseWheel;
            }
            static void sv_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
            {
                ScrollViewer scrollviewer = sender as ScrollViewer;
                if (e.Delta > 0)
                    scrollviewer.LineLeft();
                else
                    scrollviewer.LineRight();
                e.Handled = true;
            }
        }
    }
