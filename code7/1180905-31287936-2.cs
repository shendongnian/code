    System.Timers.Timer timer = new System.Timers.Timer();
    timer.Interval = 15 * 1000;
    timer.Elapsed += timer_Elapsed;
    timer.Start();
    int timerCount=0;
    void timer_Elapsed(object sender, EventArgs e)
    {
     timerCount++;
     int timeElapsed = timerCount * 15;
    }
