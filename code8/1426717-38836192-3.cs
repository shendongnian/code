    public void OnClientData(DataType data)
    {
        // TODO find out the web client connection id 
        // send the data to the web client
        Clients.Client("webClientConnectionId")
            .DataFromClient(clientId, data);
    }
