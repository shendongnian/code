    public void ResetTimer(object sender, EventArgs e)
    {
        timer.Stop();
        timer.Start();
    }
    ...
    
    button1.Click += ResetTimer;
