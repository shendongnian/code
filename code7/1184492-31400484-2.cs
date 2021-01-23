    public Task Reconnect(string connectionId)
    {
       Context.Clients[connectionId].reRegister();       
       return null;
    }
