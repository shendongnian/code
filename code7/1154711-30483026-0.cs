    Timer timer = new Timer();
    timer.Interval = 10000;
    timer.Tick += timer_Tick;
    timer.Start();
    void timer_Tick(object sender, EventArgs e)
    {
        System.Diagnostics.Process.Start("http://www.stackoverflow.com");
    }
