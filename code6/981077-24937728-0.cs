	const string tcpUri = "net.tcp://localhost:9038";
	using (var netTcpHost = new WebServiceHost(
		typeof(DashboardService),
		new Uri(tcpUri)))
	{
		netTcpHost.Description.Behaviors.Add(new ServiceMetadataBehavior());
		netTcpHost.AddServiceEndpoint(
			typeof(IMetadataExchange),
			MetadataExchangeBindings.CreateMexTcpBinding(),
			"mex");
		netTcpHost.AddServiceEndpoint(
			typeof(IDashboardService),
			new NetTcpBinding(),
			"dashboard");
	
		netTcpHost.Description.Behaviors.Add(new ServiceDiscoveryBehavior());
		netTcpHost.AddServiceEndpoint(new UdpDiscoveryEndpoint());
	
		netTcpHost.Open();
		Console.WriteLine("Hosted at {0}. Hit any key to shut down", tcpUri);
		Console.ReadLine();
	
		netTcpHost.Close();
	}
