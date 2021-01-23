    private void btnrun_Click(object sender, RoutedEventArgs e)
    {
        t = 0;
        Start_timer();
    }
    public void Start_timer()
    {
        if (timer2 != null)
        {
            timer2 -= timer_Tick2; // unassigns the event handler
            timer2.Stop(); // stops the timer
        }
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
