    ServiceHost host = new ServiceHost(typeof(Service1), new Uri(baseAddress));
    
    host.AddServiceEndpoint(typeof(IService1), new WebHttpBinding(), "")
    .Behaviors.Add(new MyWebHttpBehavior());
    host.Open();
    Console.WriteLine("Host opened");
    
    WebClient c = new WebClient();
    Console.WriteLine(c.DownloadString(baseAddress + "/Get?Id=" + Guid.NewGuid().ToString()));
