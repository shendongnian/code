    private static void _OnClick(object e, RoutedEventArgs args)
    {
        ToolBar toolBar = (ToolBar)e;
        ButtonBase bb = args.OriginalSource as ButtonBase;
        if (toolBar.IsOverflowOpen && bb != null && bb.Parent == toolBar)
            toolBar.Close();
    }
