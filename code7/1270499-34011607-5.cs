    private void Button_Click(object sender, RoutedEventArgs e)
    {
        MyScrollViewer.ScrollToVerticalOffset(0);
    }
    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        var scrollableHeight = MyScrollViewer.ScrollableHeight;
        var height= scrollableHeight / 2;
        MyScrollViewer.ScrollToVerticalOffset(height);
    }
    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
        MyScrollViewer.ScrollToVerticalOffset(MaxHeight);
    }
}
