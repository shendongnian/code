    protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
    {
        if (menu.IsVisible && e.Source != menu && !IsMenuChildMouseDown(e.Source))
        {
            menu.Visibility = Visibility.Collapsed;
        }
        base.OnPreviewMouseDown(e);
    }
