    private void OnTimerTick(object sender, EventArgs e)
    {
        uint idleTime = this.GetIdleTime();
        if (idleTime > 5000)
        {
            this.Close();
        }
    }
