       private int hitCount = 0;
       public TimeSpan CurrentTimeSpan;  
        private void RunInterval()
        {
            RunTimer(new TimeSpan(0, 0, 0, 30));
        }
        private void RunTimer(TimeSpan Timer)
        {
            DispatcherTimer timer1 = new DispatcherTimer();
            timer1.Interval = new TimeSpan(0, 0, 0, 1);
            CurrentTimeSpan = Timer;
            timer1.Tick += Timer1OnTick;
        }
        private void Timer1OnTick(object sender, object o)
        {
            if(hitCount == 10)
            {
                  (sender as DispatchTimer).Tick -= Timer1OnTick
            }
            DispatcherTimer timer = (DispatcherTimer)sender;
            CurrentTimeSpan = CurrentTimeSpan.Subtract(timer.Interval);
            if (CurrentTimeSpan.TotalSeconds == 0)
            {
                timer.Stop();
            }
        }
