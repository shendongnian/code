    var hubConnection = new HubConnection("my server url");
    var myHub = hubConnection.CreateHubProxy("my hub name");
    hubConnection.Start(new CustomHttpClient((sender, certificate, chain, sslPolicyErrors) =>
                    {
                        //put some validation logic here if you want to.
                        return true;
                    }));
