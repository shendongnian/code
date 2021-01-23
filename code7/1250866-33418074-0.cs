    private const int SCROLL_PADDING = 10;
    private void lblTop_GotKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
            {
                if (scrollViewer == null) return;
                FrameworkElement element = e.OriginalSource as FrameworkElement;
                var transform = element.TransformToVisual(scrollViewer);
                var positionInScrollViewer = transform.Transform(new Point(0, 0));
    
                //Scrolls the viewer down far enough to see this control + the control directly below it.
                if (positionInScrollViewer.Y < 0 ||
                    positionInScrollViewer.Y + SCROLL_PADDING > scrollViewer.ViewportHeight)
                {
                   scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset +
                        positionInScrollViewer.Y - SCROLL_PADDING);
                }
    
    
            }
