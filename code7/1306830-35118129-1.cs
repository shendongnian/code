    public void ReceiveClientData()
    {
        if (this.ValidateConnection())
        {
            this._clientSocket.ReceiveAsync().Wait();
        }
    }
