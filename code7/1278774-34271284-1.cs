    private Timer timer;
    public MainPage()
    {        
        this.InitializeComponent();
        timer = new Timer(timerCallback, null, (int)TimeSpan.FromMinutes(1).TotalMilliseconds, Timeout.Infinite);
    }
    private async void timerCallback(object state)
    {
        // do some work not connected with UI
        await Window.Current.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
            () => {
                // do some work on UI here;
            });
    }
