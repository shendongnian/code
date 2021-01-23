    void OnConnectionOpened(object sender, OnClientConnectArgs e)
    {
        //Add the subscription
        this.Subscribe(new XSubscriptions{Event = "notify",Alias = this.Alias});
        // Notify everyone of the new client.
        this.SendToAll("New client. Called right from OnConnectionOpened.", "notify");
    }
