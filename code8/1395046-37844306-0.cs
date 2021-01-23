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
                Stopwatch s30 = new Stopwatch();
                s30.Start();
                while (s.Elapsed < TimeSpan.FromSeconds(30))
                {
                }
                s30.Stop();
            }
            s.Stop();
        });
    }
