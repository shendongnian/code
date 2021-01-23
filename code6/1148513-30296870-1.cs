    using System.Windows.Forms;
    //...your stuff about query string...
    _hub = connection.CreateHubProxy(HubName);
    
    //quick helper to avoid repeating the connection starting code
    var connect = new Action(() => 
    {
        connection.Start(new LongPollingTransport()).Wait();
    });
    Timer t = new Timer();
    t.Interval = 5000;
    t.Tick += (s, e) =>
    {
        t.Stop();
        connect();
    }
    connection.Closed += (s, e) => 
    {
        t.Start(); 
    }
    connect();
