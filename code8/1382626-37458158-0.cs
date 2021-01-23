    protected override void OnStop()
    {
        base.OnStop();
    
        if (googleApiClient != null)
        {
            LocationServices.FusedLocationApi.Dispose();
            googleApiClient.StopAutoManage(this);
            googleApiClient.Disconnect();
            googleApiClient.Dispose();
            googleApiClient = null;
        }
    }
    
    protected override async void OnRestart()
    {
        base.OnRestart();
        await InitializeGoogleApis();
    }
