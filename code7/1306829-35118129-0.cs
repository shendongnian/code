    public void ReceiveClientData()
    {
        if (this.ValidateConnection())
        {
            var _ = this._clientSocket.ReceiveAsync();
        }
    }
