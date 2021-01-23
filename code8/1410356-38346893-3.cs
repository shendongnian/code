    public MainPage()
    {
        this.InitializeComponent();
    
        CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
        // Set the BackgroundElement instead of the entire Titlebar grid
        // so that we can add clickable element in title bar.
        Window.Current.SetTitleBar(BackgroundElement);
    }
