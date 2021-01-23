    private void button1_Click(object sender, EventArgs e)
    {
        button1.BackColor = Color.Azure;
        var aTimer = new System.Timers.Timer(2000);
        aTimer.Elapsed += OnTimedEvent;
        aTimer.Enabled = true;
    }
    private  void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
        button1.BackColor =  SystemColors.Control;
    }
