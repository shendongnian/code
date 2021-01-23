    // In your designer:
    this.timer.Enabled = false;
    this.timer.Interval = 200;
    this.timer.Tick += new System.EventHandler(this.timer_Tick);
    // when starting the progress:  
    pbTime.Value = 0
    this.timer.Enabled = true; 
    private void timer_Tick(object sender, EventArgs e)
    {
        if (pbTime.Value < 100)
            pbTime.Value += 10;
    }
