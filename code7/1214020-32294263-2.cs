            private void InitializeThread()
            {
                var timer = new BackgroundTimer();
                timer.Interval = 1000; // sleep 1 second between each iteration.
                timer.DoWork += timer_DoWork;
                timer.Start();
            }
    
            void timer_DoWork(object sender, DoWorkEventArgs e)
            {
                // your desired operation.
            }
