    private _myServiceHost;
    
    protected override void OnStart(string[] args)
    {
        if(_myServiceHost != null)
        {
            //Close the connection if the service was already opened.
            _myServiceHost.Close();
        }
    
        // 2nd Procedure:
        // Use the binding in a service
        // Create the Type instances for later use and the URI for 
        // the base address.
        Type contractType = typeof(ICalculator);
        Type serviceType = typeof(Calculator);
        Uri baseAddress = new Uri("http://localhost:8036/SecuritySamples/");
        
        // Create the ServiceHost and add an endpoint, then start
        // the service.
        _myServiceHost = new ServiceHost(serviceType, baseAddress);
        _myServiceHost.AddServiceEndpoint(contractType, myBinding, "secureCalculator");
        
        //enable metadata
        ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
        smb.HttpGetEnabled = true;
        _myServiceHost.Description.Behaviors.Add(smb);
        
        _myServiceHost.Open();
    }
    //Adding a close on OnStop gives you a more graceful shutdown of your service, letting clients finish the work they are currently on
    protected override void OnStop()
    {
        if(_myServiceHost != null)
        {
            _myServiceHost.Close();
            _myServiceHost = null;
        }
    }
