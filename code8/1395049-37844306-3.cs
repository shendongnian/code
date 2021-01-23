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
                Stopwatch s30 = new Stopwatch();
                s30.Start();
                //Method to run
                while (s.Elapsed < TimeSpan.FromSeconds(30))
                {
                }
                s30.Stop();
            }
            s.Stop();
        });
    }
