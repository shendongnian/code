     public MainWindow()
        {
            InitializeComponent();
            var timer = new System.Timers.Timer();
            timer.Elapsed += OnTimedEvent;
            timer.Interval = 1000;
            timer.Enabled = true;
        }
        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {            
            OnPropertyChanged("NameOfProperty");
        }
