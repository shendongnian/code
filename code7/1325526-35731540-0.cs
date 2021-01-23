        //Create the Performance Counter for the current Process
        PerformanceCounter myAppCPU = new PerformanceCounter("Process", "% Processor Time", Process.GetCurrentProcess().ProcessName, true);
        public MainWindow()
        {
            InitializeComponent();
            //Initialize a timer
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            //Check the CPU every 3 seconds
            dispatcherTimer.Interval = new TimeSpan(0, 0, 3);
            //Start the Timer
            dispatcherTimer.Start();
        }
        //Every 3 seconds the timer ticks
        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            //Write the result to the content of a label (CPULabel)
            CPULabel.Content = $"CPU % = {myAppCPU.NextValue()}";
        }
