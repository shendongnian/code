    protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
    {
        if (mainMenuBar.IsVisible && e.Source != mainMenuBar&& !IsMenuChildMouseDown(e.Source as FrameworkElement))
        {
            mainMenuBar.Visibility = Visibility.Collapsed;
        }
        base.OnPreviewMouseDown(e);
    }
