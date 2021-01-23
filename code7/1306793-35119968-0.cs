    private async void OnVisibleBoundsChanged(ApplicationView sender, object args)
    {
        var currentView = ApplicationView.GetForCurrentView();
        if (currentView.Orientation == ApplicationViewOrientation.Portrait)
        {
            await StatusBar.GetForCurrentView().ShowAsync();
        }
        else if (currentView.Orientation == ApplicationViewOrientation.Landscape)
        {
            await StatusBar.GetForCurrentView().HideAsync();
        }
    }
