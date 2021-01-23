    protected override void OnClosed ( EventArgs e )
    {
       base.OnClosed(e);
       SystemEvents.TimeChanged -= SystemEvents_TimeChanged;
    }
    
    protected override void OnLoad ( EventArgs e )
    {
       base.OnLoad(e);
       SystemEvents.TimeChanged += SystemEvents_TimeChanged;
    }
            
    void SystemEvents_TimeChanged ( object sender, EventArgs e )
    {
       TimeZoneInfo.ClearCachedData();
    }
    
    private void timer1_Tick ( object sender, EventArgs e )
    {
       label1.Text = DateTime.Now.ToString();
    }
