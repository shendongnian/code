    public void CallingService()
    {
        var adress = new EndpointAddress
        (new Uri("..."));    
        var binding = new BasicHttpBinding{...};          
        var serviceProxy = new SomeWebServiceClient(binding, adress);
        // adding interceptor
        serviceProxy.Endpoint.Behaviors.Add(new SamtakEndpointBehavior());
        serviceProxy.CallSomeMethod();
        // enjoy
    }
