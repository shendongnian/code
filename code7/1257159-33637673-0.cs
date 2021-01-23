    private void OnNavigatedToPage(object sender, NavigationEventArgs e)
    {
        // After a successful navigation set keyboard focus to the loaded page
        if (e.Content is Page && e.Content != null)
        {
            var control = (Page)e.Content;
            control.Loaded += Page_Loaded;
        }
    }
    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
        ((Page)sender).Focus(FocusState.Programmatic);
        ((Page)sender).Loaded -= Page_Loaded;
        this.CheckTogglePaneButtonSizeChanged();
    }
