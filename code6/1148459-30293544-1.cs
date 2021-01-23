    public MainPage()
    {
        this.InitializeComponent();
    
        DispatcherTimer timer = new DispatcherTimer();
        timer.Tick += Timer_Tick;
        timer.Start();
    }
    
    private void Timer_Tick(object sender, object e)
    {
        DateTime dateTime = DateTime.Now;
        this.hourHand.Angle = 30 * dateTime.Hour * dateTime.Minute / 2;
        this.minuteHand.Angle = 6 * dateTime.Minute + dateTime.Second / 10;
        this.secondHand.Angle = 6 * dateTime.Second + dateTime.Millisecond / 166;
    }
