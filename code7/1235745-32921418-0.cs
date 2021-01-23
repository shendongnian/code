MyList.Loaded += (sender, e) =>
{
    var scrollBar = ((FrameworkElement)VisualTreeHelper.GetChild(MyList, 0)).FindName("VerticalScrollBar") as ScrollBar;
    scrollBar.Margin = new Thickness(-10, 0, 0, 0);
};
