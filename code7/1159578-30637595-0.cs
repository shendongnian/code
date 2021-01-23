        public MainViewModel(IDataService dataService)
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(3);
            timer.Tick +=timer_Tick;
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            AddConfigurationError("err"); 
        }
