    {
        client.Send(msg);
        taskbarNotifier3.CloseClick+=new EventHandler(CloseClick);
        taskbarNotifier3.Show("Email Successfully Sent!!!", "GOOB BYE!!!.", 500, 3000, 500);
        this.Hide();
        
        System.Windows.Forms.Timer aTimer = new System.Windows.Forms.Timer();
        aTimer.Interval = 3000;
        aTimer.Tick += OnTimedEvent;
        aTimer.Enabled = true;
    }
    private void CloseClick(...)
    {
        this.Close();
    }
    private void OnTimedEvent(Object source, EventArgs e)
    {
        this.Close();
    }
