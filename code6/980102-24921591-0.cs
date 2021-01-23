    DefaultWampChannelFactory factory = new DefaultWampChannelFactory();
    IWampChannel<JToken> channel = factory.CreateChannel("ws://localhost:9090/ws");
    
    IWampClientConnectionMonitor monitor = channel.GetMonitor();
    monitor.ConnectionError += ConnectionError;
    monitor.ConnectionEstablished += ConnectionEstablished;
    monitor.ConnectionLost += ConnectionLost;
    
    await channel.OpenAsync();
