    private void btnJSON_Click(object sender, RoutedEventArgs e)
    {
        Task.Factory.StartNew(async() =>
        {
            //Timing Logic
            var geTimerDelay = 2;
            Stopwatch s = new Stopwatch();
            s.Start();
            while (s.Elapsed < TimeSpan.FromHours(geTimerDelay))
            {
                //Method to run
                await Task.Delay(TimeSpan.FromSeconds(30));
            }
            s.Stop();
        });
    }
