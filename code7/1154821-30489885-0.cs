    var hubConnection = new HubConnection("http://localhost:14382");
    var proxy1 = hubConnection.CreateHubProxy("Hub1");
    var proxy2 = hubConnection.CreateHubProxy("Hub2");
    hubConnection.Start().Wait();
    
