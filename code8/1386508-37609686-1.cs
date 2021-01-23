    private SplashScreen splash; // Variable to hold the splash screen object
    internal bool dismissed = false; // Variable to track splash screen dismi
    internal Frame rootFrame;
    private readonly DispatcherTimer _timer;
    public ExtendedSplash(SplashScreen splashscreen, bool loadState)
    {
        this.InitializeComponent();
        StatusBar statusbar = StatusBar.GetForCurrentView();
        statusbar.HideAsync();
        if (splash != null)
        {
            splash.Dismissed += new TypedEventHandler<SplashScreen, Object>(D
        }
        rootFrame = new Frame();
        _timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(2)
        };
        _timer.Tick += ChangeImage;
        _timer.Start();
    }
    private void ChangeImage(object sender, object e)
    {
        var totalItems = ImageFlipView.Items.Count;
        var newItemIndex = (ImageFlipView.SelectedIndex + 1) % totalItems;
        ImageFlipView.SelectedIndex = newItemIndex;
    }   
    void DismissedEventHandler(SplashScreen sender, object e)
    {
        dismissed = true;            
    }
 
