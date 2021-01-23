    private void ScrolltoBottom(TextBox textBox)
    {
        var grid = (Grid)VisualTreeHelper.GetChild(textBox, 0);
        for (var i = 0; i < VisualTreeHelper.GetChildrenCount(grid); i++)
        {
            object obj = VisualTreeHelper.GetChild(grid, i);
            if (!(obj is ScrollViewer)) continue;
            //((ScrollViewer)obj).ChangeView(0.0f, ((ScrollViewer)obj).ExtentHeight, 1.0f);
            ((ScrollViewer)obj).ScrollToVerticalOffset(((ScrollViewer)obj).ExtentHeight);
            break;
        }
    }
