        private System.Windows.Forms.Timer MyTimer;
        private TimeSpan TargetTime = new TimeSpan(11, 48, 0);
        
        public Form1()
        {
            InitializeComponent();
            MyTimer = new System.Windows.Forms.Timer();
            MyTimer.Interval = (int)MillisecondsToTargetTime(TargetTime);
            MyTimer.Tick += new EventHandler(times);
            MyTimer.Start();
        }
        private double MillisecondsToTargetTime(TimeSpan ts)
        {
            DateTime dt = DateTime.Today.Add(ts);
            if (DateTime.Now > dt)
            {
                dt = dt.AddDays(1);
            }
            return dt.Subtract(DateTime.Now).TotalMilliseconds;
        }
        private void times(object sender, EventArgs e)
        {
            MyTimer.Stop();
            MessageBox.Show("It's " + TargetTime.ToString(@"hh\:mm"));
            MyTimer.Interval = (int)MillisecondsToTargetTime(TargetTime);
            MyTimer.Start();
        }
