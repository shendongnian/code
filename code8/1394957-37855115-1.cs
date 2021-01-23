    public MainPage()
    {
        InitializeComponent();
        CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
        // Set TitleBar to BackgroundElement instead of the entire grid
        // Clicks on the BackgroundElement will be treated as clicks on the title bar.
        Window.Current.SetTitleBar(BackgroundElement);
    }
