    private void AppBarToggleButton_Click(object sender, RoutedEventArgs e)
    {
        Debug.WriteLine(BottomAppBar.ActualHeight.ToString());
        if (BottomAppBar.ClosedDisplayMode == AppBarClosedDisplayMode.Compact)
           BottomAppBar.ClosedDisplayMode = AppBarClosedDisplayMode.Minimal;
        else BottomAppBar.ClosedDisplayMode = AppBarClosedDisplayMode.Compact;
    }
