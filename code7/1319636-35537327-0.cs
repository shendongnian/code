    public void Run(IBackgroundTaskInstance taskInstance)
    {
        var details = taskInstance.TriggerDetails as AppServiceTriggerDetails;
        appServiceconnection = details.AppServiceConnection;
        appServiceconnection.RequestReceived += OnRequestReceived;
    }
    private async void OnRequestReceived(AppServiceConnection sender,
        AppServiceRequestReceivedEventArgs args)
    {
        var messageDeferral = args.GetDeferral();
        ValueSet arguments = args.Request.Message;
        ValueSet result = new ValueSet();
        // read values from arguments
        // do the processing
        // put data for the caller in result
        await args.Request.SendResponseAsync(result);
        messageDeferral.Complete(); 
    }
