    public Task Disconnect(string connectionId)
    {       
        lock (_lock)
        {
             var connections = _registeredClients.Where(c => c.Value.Any(connection => connection == connectionId)).FirstOrDefault();     
             // if we are tracking a client with this connection remove it
             if (!CollectionUtil.IsNullOrEmpty(connections.Value))
             {
                connections.Value.Remove(connectionId);     
                // if there are no connections for the client, remove the client from the tracking dictionary
                if (CollectionUtil.IsNullOrEmpty(connections.Value))
                {
                    _registeredClients.Remove(connections.Key);
                }
             }                 
        return null;
    }
