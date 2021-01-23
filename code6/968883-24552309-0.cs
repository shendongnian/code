            _timer = new DispatcherTimer();
            _timer.Tick += timer_Tick;
            _timer.Interval = new TimeSpan(0, 0, 0, 1);
            _timer.Start();
        private void timer_Tick(object sender, EventArgs e)
        {
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += (s, a) =>
            {
                //do your stuff
            };
            
            backgroundWorker.RunWorkerAsync();
        }
