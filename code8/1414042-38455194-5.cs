    Uri baseAddress = new Uri("http://localhost:8000/HelloService");
    string address = "http://localhost:8000/HelloService/MyService";
    using (ServiceHost serviceHost = new ServiceHost(typeof(HelloService), baseAddress))
    {
        serviceHost.AddServiceEndpoint(typeof(IHello), new BasicHttpBinding(), address);
        serviceHost.Open();
        Console.WriteLine("Press <enter> to terminate service");
        Console.ReadLine();
        serviceHost.Close();
    }
