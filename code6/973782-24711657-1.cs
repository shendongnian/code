    DispatcherTimer tmr;
    int test;
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        string QueryStr = "";
        NavigationContext.QueryString.TryGetValue("myNumber", out QueryStr);
        test = (int.Parse(QueryStr));
        LoadTimer();
    }
    
    public void LoadTimer()
    {
        tmr = new DispatcherTimer();
        Deployment.Current.Dispatcher.BeginInvoke(() =>
        {
            tmr.Interval = new TimeSpan(0, 0, 1);
            tmr.Tick += tmr_Tick;
            tmr.Start();
        });
    }
    
    void tmr_Tick(object sender, EventArgs e)
    {
        test++;
        TextBlock.Text = test.ToString();
    }
