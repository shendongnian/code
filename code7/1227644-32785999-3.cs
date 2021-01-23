    Windows.Foundation.Size originalSize;
    private void GrabLoaded(object sender, RoutedEventArgs e)
    {
        originalSize = MyTextBox.RenderSize;
    }
    private void GrabDelta(object sender, Windows.UI.Xaml.Controls.Primitives.DragDeltaEventArgs e)
    {
        MyTextBox.Width = MyTextBox.ActualWidth + e.HorizontalChange;
        MyTextBox.Height = MyTextBox.ActualHeight + e.VerticalChange;
    }
    private void GrabDoubleTapped(object sender, Windows.UI.Xaml.Input.DoubleTappedRoutedEventArgs e)
    {
        MyTextBox.Height = originalSize.Height;
        MyTextBox.Width = originalSize.Width;
    }
