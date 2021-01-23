    private void btnJSON_Click(object sender, RoutedEventArgs e)
    {
        Task.Factory.StartNew(() =>
        {
            //Timing Logic
            var geTimerDelay = 2;
            Stopwatch s = new Stopwatch();
            s.Start();
            while (s.Elapsed < TimeSpan.FromHours(geTimerDelay))
            {
                //Method to run
                Thread.Sleep(TimeSpan.FromSeconds(30));
            }
            s.Stop();
        });
    }
