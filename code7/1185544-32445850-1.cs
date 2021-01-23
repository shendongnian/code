    public MainPage()
    {
       InitializeComponent();
       await Windows.UI.ViewManagement.StatusBar.GetForCurrentView().HideAsync();
       Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().SuppressSystemOverlays = true;
    }
