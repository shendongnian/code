    private ServiceHost host;
    
    private void HostWcfService()
    {
            //Create a URI to serve as the base address
             Uri httpUrl = newUri("http://localhost:1256/MyService/Service");
             
             //Create ServiceHost
             host = newServiceHost(typeof(MyService.IService), httpUrl);
             
             //Add a service endpoint
             host.AddServiceEndpoint(typeof(MyService.IService), newWSHttpBinding(), "");
             
             //Enable metadata exchange
             ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
             smb.HttpGetEnabled = true;
             host.Description.Behaviors.Add(smb);
    
             //Start the Service
             host.Open();
    
    }
