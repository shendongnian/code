    private void PivotItem_PointerWheelChanged(object sender, PointerRoutedEventArgs e)
    {
        if (e.GetCurrentPoint(scrollViewer).Properties.MouseWheelDelta == (-120))
        {
            // On Mouse Wheel scroll Backward
            scrollViewer.ChangeView(null, scrollViewer.VerticalOffset + Window.Current.CoreWindow.Bounds.Height / 7, null, false);
        }
        if (e.GetCurrentPoint(scrollViewer).Properties.MouseWheelDelta == (120))
        {
            // On Mouse Wheel scroll Forward
            scrollViewer.ChangeView(null,scrollViewer.VerticalOffset - Window.Current.CoreWindow.Bounds.Height / 7, null, false);
        }
    }
