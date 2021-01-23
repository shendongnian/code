    private DispatcherTimer _dispatcherTimer;
    private void SetUpTimer(){
        _dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        _dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
        _dispatcherTimer.Interval = TimeSpan.FromMilliseconds(500);
        _dispatcherTimer.Start();
    }
    
    private void dispatcherTimer_Tick(object sender, EventArgs e)
    {
        LoadRequests();
    }
