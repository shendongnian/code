    private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        if(e.NewSize.Width <= 500)
        {
            MyScrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
        }
        else
        {
            MyScrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
        }
        if (e.NewSize.Height <= 500)
        {
            MyScrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
        }
        else
        {
            MyScrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
        }
    }
