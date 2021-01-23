     public sealed class IgnoreMouseWheelBehavior : Behavior<UIElement>
        {
            protected override void OnAttached()
            {
                base.OnAttached();
                AssociatedObject.PreviewMouseWheel += AssociatedObjectPreviewMouseWheel;
            }
    
            protected override void OnDetaching()
            {
                AssociatedObject.PreviewMouseWheel -= AssociatedObjectPreviewMouseWheel;
                base.OnDetaching();
            }
    
            private void AssociatedObjectPreviewMouseWheel(object sender, MouseWheelEventArgs e)
            {
                e.Handled = true;
    
                var mouseWheelEventArgs = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta)
                         {
                             RoutedEvent = UIElement.MouseWheelEvent
                         };
                AssociatedObject.RaiseEvent(mouseWheelEventArgs);
            }
