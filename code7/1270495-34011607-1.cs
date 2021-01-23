    private void Button_Click(object sender, RoutedEventArgs e)
    {
        MyScrollViewer.ScrollToVerticalOffset(0);
    }
    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
      
        var a = MyScrollViewer.ExtentHeight;
        a = a / 4;
        TextBlock.Text = string.Format("{0}",a);
     
        MyScrollViewer.ScrollToVerticalOffset(a);
    }
    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
        MyScrollViewer.ScrollToVerticalOffset(MaxHeight);
    }
}
