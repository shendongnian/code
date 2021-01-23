    public MainPage()
    {
    	this.InitializeComponent();
    	CoreWindow.GetForCurrentThread().Activated += CoreWindowOnActivated;
    }
    
    private void CoreWindowOnActivated(CoreWindow sender, WindowActivatedEventArgs args)
    {
    	if(args.WindowActivationState == CoreWindowActivationState.Deactivated)            
    		this.contetProtector.Visibility = Visibility.Visible;
    	else
    		this.contetProtector.Visibility = Visibility.Collapsed;
    }
