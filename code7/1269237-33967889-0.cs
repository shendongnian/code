    DispatcherTimer timer;
    private void BtnStart_Click(object sender, RoutedEventArgs e)
    {
        if (!w.IsRunning)
        {
            w.Start();
            if (timer == null )
            {
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Tick += timer_Tick;
            }
            timer.Start();
        }
    }
    void timer_Tick(object sender, EventArgs e)
    {
        if (w.IsRunning)
        {                
            TbClock.Text = w.Elapsed.Hours + ":" + w.Elapsed.Minutes + ":" + w.Elapsed.Seconds;
            Debug.WriteLine(w.Elapsed.Hours + ":" + w.Elapsed.Minutes + ":" + w.Elapsed.Seconds);
        }
    }
    private void BtnEnd_Click(object sender, RoutedEventArgs e)
    {
        if (w.IsRunning)
        {              
            w.Stop();
            w.Reset();
            timer.Stop();
        }
    }
