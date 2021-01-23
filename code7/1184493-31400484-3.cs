    public void Register(HubClientPayload payload, string connectionId)
    {       
        lock (_lock)
        {
            List<String> connections;
            if (_registeredClients.TryGetValue(payload.UniqueID, out connections))
            {
                 if (!connections.Any(connection => connectionID == connection))
                 {
                     connections.Add(connectionId);
                 }
            }
            else
            {
                 _registeredClients[payload.UniqueID] = new List<string> { connectionId };
            }
        }        
    }
