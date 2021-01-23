    var baseUri = new Uri("http://localhost:10004/");
    var serviceHost = new ServiceHost(typeof(HelloWorldService), baseUri);
    try
    {
        var unsecureServiceEndpoint = serviceHost.AddServiceEndpoint(typeof(IHelloWorldService), new WebHttpBinding(), "Service.svc");
        unsecureServiceEndpoint.Behaviors.Add(new WebHttpBehavior());
        unsecureServiceEndpoint.Name = "UnsecureEndpoint";
    
        var secureBinding = new WebHttpBinding(WebHttpSecurityMode.TransportCredentialOnly);
        secureBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
        var secureServiceEndpoint = serviceHost.AddServiceEndpoint(typeof(IHelloWorldService), secureBinding, "Service2.svc");
        secureServiceEndpoint.Behaviors.Add(new WebHttpBehavior());
        secureServiceEndpoint.Name = "SecureEndpoint";
    
        serviceHost.Description.Behaviors.Add(new ServiceMetadataBehavior { HttpGetEnabled = true });
        serviceHost.Open();
    
        Console.WriteLine("Hosting - {0} @ {1}", unsecureServiceEndpoint.Name, unsecureServiceEndpoint.Address);
        Console.WriteLine("Hosting - {0} @ {1}", secureServiceEndpoint.Name, secureServiceEndpoint.Address);
    
        Console.WriteLine("Press <Enter> to stop the services.");
        Console.ReadLine();
    
        serviceHost.Close();
    }
    catch (CommunicationException ce)
    {
        Console.WriteLine("An exception occurred: {0}", ce.Message);
        serviceHost.Abort();
    }
