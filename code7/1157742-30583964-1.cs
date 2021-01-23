    private DispatcherTimer dispatcherTimer;
    public MainWindow()
    {
        InitializeComponent();
        //Create a timer with interval of 2 secs
        dispatcherTimer = new DispatcherTimer();
        dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
        dispatcherTimer.Interval = new TimeSpan(0, 0, 2);
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        //Things which happen before the timer starts
        MyLabel.Visibility = System.Windows.Visibility.Visible;
    
        //Start the timer
        dispatcherTimer.Start(); 
    }
    private void dispatcherTimer_Tick(object sender, EventArgs e)
    {
        //Things which happen after 1 timer interval
        MessageBox.Show("Show some data");
        MyLabel.Visibility = System.Windows.Visibility.Collapsed;
    
        //Disable the timer
        dispatcherTimer.IsEnabled = false;
    }
