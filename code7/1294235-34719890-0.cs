    public event ChangedEvent ExternalEvent;
    private DispatcherTimer _timer;
    private ChangedEventArgs _lastChangedArgs;
    public MyControl()
    { 
        InitializeComponent();
        _timer = new DispatcherTimer();
        _timer.Tick += new EventHandler(dispatcherTimer_Tick);
        _timer.Interval = new TimeSpan(0,0,0,350);
        InternalEventGeneratingControl.ChangedEvent += new ChangedEventHandler(ChangedHandler);
    }
    private void dispatcherTimer_Tick(object sender, EventArgs e)
    {
        _timer.Stop();
       if (ExternalEvent != null)
           ExternalEvent(this, _lastChangedArgs);
    }
    private void ChangedHandler(object sender, ChangedEventArgs e)
    {
       _timer.Stop();
       _lastChangedArgs = e;
       _timer.Start();
    }
