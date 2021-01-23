    private void TimerEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            _serviceTimer.Enabled = false;
            DoWork();
            _serviceTimer.Enabled = true;
        }
