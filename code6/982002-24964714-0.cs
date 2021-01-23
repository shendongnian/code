    public async Task StartConnection()
    {
        var connection = new HubConnection("http://localhost:32986/");
        var hub = connection.CreateHubProxy("MessageHub");
        await connection.Start();
        await hub.Invoke("SendMessage", "", "");
        // ...
    }
    // or
    public void StartConnection()
    {
        var connection = new HubConnection("http://localhost:32986/");
        var hub = connection.CreateHubProxy("MessageHub");
        connection.Start().Wait();
        hub.Invoke("SendMessage", "", "").Wait();
        // ...
    }
