    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        SystemNavigationManager.GetForCurrentView().BackRequested += Page_BackRequested;
    }
    
    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
        SystemNavigationManager.GetForCurrentView().BackRequested -= Page_BackRequested;
    }
    
    private void Page_BackRequested(object sender, BackRequestedEventArgs e)
    {
        if (MyGrid.Visibility == Visibility.Visible)
        {
            MyGrid.Visibility = Visibility.Collapsed;
            e.Handled = true;
        }
        else
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
                e.Handled = true;
            }
        }
    }
