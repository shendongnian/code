    public MainPage()
        {
            this.InitializeComponent();            
            
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler<object>(timer_Tick);
            timer.Interval = TimeSpan.FromMilliseconds(bpm);
    }
