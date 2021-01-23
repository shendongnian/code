        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            IInputElement element = FocusManager.GetFocusedElement(this);
            if (element != null && e.Source != element)
            {
                MouseWheelEventArgs args = new MouseWheelEventArgs(Mouse.PrimaryDevice, e.Timestamp, e.Delta) { RoutedEvent = UIElement.MouseWheelEvent };
                element.RaiseEvent(args);
                e.Handled = true;
            }
            base.OnMouseWheel(e);
        }
