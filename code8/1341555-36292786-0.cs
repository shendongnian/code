    SystemNavigationManager.GetForCurrentView().BackRequested += (sender, e) =>
    {
        if (!e.Handled && Frame.CanGoBack)
        {
            e.Handled = true;
            AppFrame.GoBack();
        }
    };
