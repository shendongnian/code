    {
        client.Send(msg);
        taskbarNotifier3.CloseClick+=new EventHandler(CloseClick);
        taskbarNotifier3.Show("Email Successfully Sent!!!", "GOOB BYE!!!.", 500, 3000, 500);
        this.Hide();
        
        System.Timers.Timer aTimer = new System.Timers.Timer(3000);
        aTimer.Elapsed += OnTimedEvent;
        aTimer.Enabled = true;
    }
    private void CloseClick(...)
    {
        this.Close();
    }
    private void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
        this.Close();
    }
