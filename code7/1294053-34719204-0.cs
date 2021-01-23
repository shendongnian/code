    public void InitializeDeviceStatus(IWcfServiceProxy serviceDisposable)
    {
        try 
        {
            DeviceStatus = serviceDisposable.Use(...);
        }
    }
