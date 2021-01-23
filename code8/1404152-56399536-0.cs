    var localEndpoint = new IPEndPoint(IPAddress.Loopback, 4321);
    var remoteEndpoint = new IPEndPoint(IPAddress.Parse("remote proxy IP"), 8080);
    ISocksRelayServer relay = new SocksRelayServer.SocksRelayServer(localEndpoint, remoteEndpoint)
    {
        Username = "...",
        Password = "..."
    };
    // Debug to console
    relay.OnLogMessage += (sender, s) => Console.WriteLine($"OnLogMessage: {s}");
    relay.OnLocalConnect += (sender, endpoint) => Console.WriteLine($"OnLocalConnect: {endpoint}");
    relay.OnRemoteConnect += (sender, endpoint) => Console.WriteLine($"OnRemoteConnect: {endpoint}");
    // Start relay server
    relay.Start();
    // Start FiddlerCore
    FiddlerApplication.Startup(...);
    // Set upstream gateway before requests
    FiddlerApplication.BeforeRequest += session =>
    {
        session["x-OverrideGateway"] = relay.LocalEndPoint.ToString();
    }
