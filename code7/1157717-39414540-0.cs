    private void StartTimers(object sender, RoutedEventArgs e)
    {
        dtimer = new DispatcherTimer();
        dtimer.Tick += new EventHandler(dTimer_Tick);
        dtimer.Interval = TimeSpan.FromMilliseconds(1);  // the small time step
        stopWatch = new StopWatch();
    
        dTimer.Start();
        stopWatch.Start();
    }
    
    private void dTimer_Tick(object sender, EventArgs e)
    {        
         currentTime = stopWatch.ElapsedMilliseconds;
            if (currentTime - oldTime > interval)
            {
                oldTime = currentTime;
                DoStuff();
            }
    }   
