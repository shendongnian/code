    class TimerAndWait
    {
        private ManualResetEvent resetEvent = new ManualResetEvent(false);
        public void DoWork()
        {
            var aTimer = new System.Timers.Timer(5000);
            aTimer.Elapsed += ATimer_Elapsed;
            aTimer.AutoReset = true;
            aTimer.Start();
            // Do something else
            resetEvent.WaitOne(); // This blocks the thread until resetEvent is set
            resetEvent.Close();
            aTimer.Stop();
        }
        private void ATimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            resetEvent.Set();
        }
    }
