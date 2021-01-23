    public void UpdateTime()
    {
        time = DateTime.Now.ToString("h:mm:ss tt");
        LBLTime.Text = time;
        LBLNext.Text = nextTime.ToShortTimeString();
    }
