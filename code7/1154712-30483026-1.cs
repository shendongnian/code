    Timer timer = new Timer();
    timer.Interval = 10000;
    timer.Tick += timer_Tick;
    timer.Start();
    void timer_Tick(object sender, EventArgs e)
    {
        System.Diagnostics.Process.Start("http://www.stackoverflow.com");
        timer.Stop();   //If you don't want to show page every 10 seconds stop the timer once it has shown the page.
    }
