    public MainPage()
    {
        InitializeComponent();
        EventRegistration();
    }
    private void EventRegistration()
    {
        SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;
        Scenes.Navigated += OnNavigated;
        SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
            Scenes.CanGoBack ?
            AppViewBackButtonVisibility.Visible :
            AppViewBackButtonVisibility.Collapsed;
    }
    private void OnNavigated(object sender, NavigationEventArgs e)
    {
        if (sender is Frame)
        {
            var sc = sender as Frame;
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
            sc.CanGoBack ?
            AppViewBackButtonVisibility.Visible :
            AppViewBackButtonVisibility.Collapsed;
        }
    }
    private void OnBackRequested(object sender, BackRequestedEventArgs e)
    {
        if (Scenes.CanGoBack)
        {
            e.Handled = true;
            Scenes.GoBack();
        }
    }
