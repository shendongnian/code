    private string useragent = string.Empty;
    private void timer2_Tick(object sender, EventArgs e)
    {
        var r = new Random();
        useragent = RandomString(r);
        timer2.Stop();
        timer2.Interval = 1;
        timer2.Start();
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(useragent)) 
            return;
        Navigate("http://example.org", useragent, null);
    }
