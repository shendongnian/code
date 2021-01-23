    public MainWindow()
    {
        InitializeComponent();
        dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
        dispatcherTimer.Tick += dispatcherTimer_Tick; // set it up here
    }
    //Executes when the stop button is hit, ends timers do while loop
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        dispatcherTimer.Start(); // start timer
    }
