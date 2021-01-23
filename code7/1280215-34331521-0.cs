    protected void Application_Start()
    {
      _bus = RabbitHutch.CreateBus("host=localhost"))
      _bus.Publish(new SystemLog() { Code = "startapplication", Message = "nomessage" });
    }
    void Session_End(object sender, EventArgs e)
    {
      _bus.Publish(new SystemLog() { Code = "sessionends", Message = "somenumber"});
    }
    protected void Application_End()
    {
      if(_bus!=null)
        _bus.Dispose();
    }
