    DispatcherTimer _dispatcherTimer = new DispatcherTimer();
    public MainWindow()
    {
        InitializeComponent();
        button1.Click += button1_Click;
        _dispatcherTimer.Tick += new EventHandler(dt_Tick);
        _dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 5);
    }
    private void button1_Click(object sender, RoutedEventArgs e)
    {
        myImage.BackgroundImage = Properties.Resources.newImage;
        _dispatcherTimer.Start();
    }
    void dt_Tick(object sender, EventArgs e)
    {
	    _dispatcherTimer.Stop();
        myImage.BackgroundImage = Properties.Resources.myImage;
    }
