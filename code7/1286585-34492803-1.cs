    public void InitTimer(int secs)
    {
        Session.Add("timer", secs);
        Timer1.Enabled = true;
    }
