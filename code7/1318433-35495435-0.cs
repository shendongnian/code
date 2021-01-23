    public RestartPortal()
    {
        InitializeComponent();
        
        // Subscribe to the Loaded event
        this.Loaded += RestartPortal_Loaded;
    }
    void RestartPortal_Loaded(object sender, RoutedEventArgs e)
    {
        // Set your values here
        alwaysOnTopCheck.IsChecked = bool.Parse(ConfigurationManager.AppSettings.Get("onTopChecked"));
        closeWhenCompleteCheck.IsChecked = bool.Parse(ConfigurationManager.AppSettings.Get("autoCloseChecked"));
    }
