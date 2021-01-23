    System.Timers.Timer timer = new System.Timers.Timer();
    timer.Interval = 15 * 1000;
    timer.Elapsed += timer_Elapsed;
    void timer_Elapsed(object sender, EventArgs e)
    {
     //your code here
    }
