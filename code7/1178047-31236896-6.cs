    private readonly static ConnectionMapping<string> _connections = 
            new ConnectionMapping<string>();
    public override Task OnConnected()
    {
        string name = Context.User.Identity.Name;
        _connections.Add(name, Context.ConnectionId);
        return base.OnConnected();
    }
    public override Task OnDisconnected(bool stopCalled)
    {
        string name = Context.User.Identity.Name;
        _connections.Remove(name, Context.ConnectionId);
        return base.OnDisconnected(stopCalled);
    }
    public void SendChatMessage(string who, string message)
    {
        string name = Context.User.Identity.Name;
        foreach (var connectionId in _connections.GetConnections(who))
        {
            Clients.Client(connectionId).addChatMessage(name + ": " + message);
        }
    }
