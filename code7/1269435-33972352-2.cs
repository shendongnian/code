    private void btnrun_Click(object sender, RoutedEventArgs e)
    {
        t = 0;
        if (timer2 == null)
            Start_timer();
    }
    public void Start_timer()
    {
        timer2 = new DispatcherTimer();
        timer2.Tick += timer_Tick2;
        timer2.Interval = new TimeSpan(0, 0, 0, 0, 1000);
        timer2.Start();
    }
    void timer_Tick2(object sender, object e)
    {
        t++;
        txttime.Text = t.ToString();
    }
