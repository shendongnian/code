        Timer _timer;
        public Form1()
        {
            //InitializeComponent();
            _timer = new Timer();
            _timer.Interval = 1000; //ms
            _timer.Elapsed += _timer_Elapsed;
        }
        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            foreach (var process in Process.GetProcesses())
            {
                //compare and perform tasks
            }
        }
