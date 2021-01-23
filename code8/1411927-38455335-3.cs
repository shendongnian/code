    DateTime value;
    bool wcfCallInProgress;
    public void GetDateTime()
    {
        var proxy = new WcfClient();
        proxy.GetCurrentDateTimeCompleted -= ProxyGetCurrentDateTimeCompleted;
        proxy.GetCurrentDateTimeCompleted += ProxyGetCurrentDateTimeCompleted;
        wcfCallInProgress = true;
        proxy.GetCurrentDateTimeAsync();
    }
    private void ProxyGetCurrentDateTimeCompleted(object sender, GetCurrentDateTimeCompletedEventArgs args)
    {
        value = args.Result;
        wcfCallInProgress = false;
    }
