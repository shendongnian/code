        const double interval60Minutes = 1000; // milliseconds to one hour
        System.Timers.Timer checkForTime = new System.Timers.Timer(interval60Minutes);
        string Check = null;
        private void Form1_Load(object sender, EventArgs e)
        {
            checkForTime.Elapsed += new ElapsedEventHandler(checkForTime_Elapsed);
            checkForTime.Enabled = true;
            checkForTime.AutoReset = false;
        }
        public void checkForTime_Elapsed(object sender, ElapsedEventArgs e)
        {
            DateTime target = new DateTime(2016, 5, 8, 11, 58, 0);
            DateTime now = DateTime.Now;
            if (target.ToString("HH:mm:ss") == now.ToString("HH:mm:ss") && (Check == null))
            {
                MessageBox.Show("Welcome Admin");
                checkForTime.Stop();
            }
        }
