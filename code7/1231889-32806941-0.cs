    System.Timers.Timer timer = new System.Timers.Timer(5 * 60 * 1000);
    timer.Elapsed += (s, e) =>
        {
           //Invoke your show dialog on the UI thread here
        };
    timer.Start();
