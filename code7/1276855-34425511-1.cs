    private void scrollViewer_PointerEntered(object sender, PointerRoutedEventArgs e)
    {
        imageNormal.Opacity = 0;
        scrollViewer.ZoomToFactor(3);
        imageZoomed.Source = new BitmapImage(new Uri(@"ms-appx:///Assets/TestPicture.jpg"));
    }
    private void scrollViewer_PointerMoved(object sender, PointerRoutedEventArgs e)
    {
        var pointerPoint = e.GetCurrentPoint(imageNormal);
        var horizontalScrollPercent = pointerPoint.Position.X / imageNormal.ActualWidth;
        var verticalScrollPercent = pointerPoint.Position.Y / imageNormal.ActualHeight;
        try
        {
            scrollViewer.ChangeView(horizontalScrollPercent * scrollViewer.ViewportWidth * scrollViewer.ZoomFactor, verticalScrollPercent * scrollViewer.ViewportHeight * scrollViewer.ZoomFactor, null);
        }
        catch { }
    }
    
    private void scrollViewer_PointerExited(object sender, PointerRoutedEventArgs e)
    {
        imageNormal.Opacity = 1;
        imageZoomed.Source = null;
    }
