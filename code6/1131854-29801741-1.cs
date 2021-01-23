    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        Grid parent = VisualTreeHelper.GetParent(UserControl1) as Grid;
        if (parent != null)
        {
            parent.Children.Remove(UserControl1);
        }
        var w = new Window
        {
            Content = UserControl1,
            Title = "sample",
            SizeToContent = SizeToContent.WidthAndHeight,
            ResizeMode = ResizeMode.CanResize
        };
        w.Show();
    }
