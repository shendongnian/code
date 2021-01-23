    namespace CSharpWPF
    {
        class MouseExtension : DependencyObject
        {
            public static bool GetScrollAnywhere(DependencyObject obj)
            {
                return (bool)obj.GetValue(ScrollAnywhereProperty);
            }
            public static void SetScrollAnywhere(DependencyObject obj, bool value)
            {
                obj.SetValue(ScrollAnywhereProperty, value);
            }
            // Using a DependencyProperty as the backing store for ScrollAnywhere.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty ScrollAnywhereProperty =
                DependencyProperty.RegisterAttached("ScrollAnywhere", typeof(bool), typeof(MouseExtension), new PropertyMetadata(false, OnScrollAnywhere));
            private static void OnScrollAnywhere(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                UIElement element = d as UIElement;
                if ((bool)e.NewValue)
                    element.PreviewMouseWheel += element_PreviewMouseWheel;
                else
                    element.PreviewMouseWheel -= element_PreviewMouseWheel;
            }
            static void element_PreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
            {
                IInputElement element = FocusManager.GetFocusedElement(sender as DependencyObject);
                if (element != null && e.Source != element)
                {
                    MouseWheelEventArgs args = new MouseWheelEventArgs(Mouse.PrimaryDevice, e.Timestamp, e.Delta) { RoutedEvent = UIElement.MouseWheelEvent };
                    element.RaiseEvent(args);
                    e.Handled = true;
                }
            }
        }
    }
