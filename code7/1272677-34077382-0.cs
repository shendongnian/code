    protected override void OnStart(string[] args)
    {
       if (myServiceHost != null)
       {
           myServiceHost.Close();
       }
       myServiceHost = new ServiceHost(typeof(Service1));
       myServiceHost.Open();
    }
