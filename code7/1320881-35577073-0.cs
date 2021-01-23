    Uri baseAddr = new Uri("http://localhost:8000/WCFService1");
    ServiceHost localHost = new ServiceHost(typeof(CalculatorService), baseAddr);
    try
    {
    localHost.AddServiceEndpoint(typeof(ICalculator), new WSHttpBinding(), "CalculatorService");
     
    ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
    smb.HttpGetEnabled = true;
    localHost.Description.Behaviors.Add(smb);
     
    localHost.Open();
    Console.WriteLine("Service initialized.");
    Console.WriteLine("Press the ENTER key to terminate service.");
    Console.WriteLine();
    Console.ReadLine();
     
    localHost.Close();
    }
    catch (CommunicationException ex)
    {
    Console.WriteLine("Oops! Exception: {0}", ex.Message);
    localHost.Abort();
    }
