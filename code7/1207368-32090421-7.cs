    public override void Configure(Funq.Container container)
    {            
        DeviceAdapter.RaiseSomeEvent += DeviceAdapter_RaiseSomeEvent;       
    }
    public void DeviceAdapter_RaiseSomeEvent(object sender, EventArgs e)
    {
        var serverEvents = Container.Resolve<IServerEvents>();
        serverEvents.NotifyAll("cmd.Handler", "Something happend!");            
    }
