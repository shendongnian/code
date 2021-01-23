    public static async void connect(string server)
    {
        hubConnection = new HubConnection(server);
        protocolHubProxy = hubConnection.CreateHubProxy("ProtocolHub");
        protocolHubProxy.On<Body>("BodiesChanged", body =>
            //call a callback to return body
        );
        await hubConnection.Start(); //wait for connection
        // add code here.
    }
