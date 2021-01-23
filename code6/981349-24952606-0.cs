    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        if (Frame.CanGoBack)
        {
            PageStackEntry lastPage = Frame.BackStack[Frame.BackStackDepth - 1];
            if (lastPage.SourcePageType == typeof(MainPage))
            {
                // do something
            }
        }
        this.navigationHelper.OnNavigatedTo(e);
    }
