    private BitmapImage image;
    
    public DetailPage()
    {
        this.InitializeComponent();
    }
    
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
    
        var testitem = e.Parameter as TestItem;
        image = testitem.ImageItem;
    
        var backStack = Frame.BackStack;
        var backStackCount = backStack.Count;
    
        if (backStackCount > 0)
        {
            var masterPageEntry = backStack[backStackCount - 1];
            backStack.RemoveAt(backStackCount - 1);
    
            // Doctor the navigation parameter for the master page so it
            // will show the correct item in the side-by-side view.
            var modifiedEntry = new PageStackEntry(
                masterPageEntry.SourcePageType,
                e.Parameter,
                masterPageEntry.NavigationTransitionInfo
                );
            backStack.Add(modifiedEntry);
        }
    
        // Register for hardware and software back request from the system
        SystemNavigationManager systemNavigationManager = SystemNavigationManager.GetForCurrentView();
        systemNavigationManager.BackRequested += DetailPage_BackRequested;
        systemNavigationManager.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
    }
    
    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
        base.OnNavigatedFrom(e);
    
        SystemNavigationManager systemNavigationManager = SystemNavigationManager.GetForCurrentView();
        systemNavigationManager.BackRequested -= DetailPage_BackRequested;
        systemNavigationManager.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
    }
    
    private void OnBackRequested()
    {
        Frame.GoBack();
    }
    
    private void DetailPage_BackRequested(object sender, BackRequestedEventArgs e)
    {
        e.Handled = true;
        OnBackRequested();
    }
