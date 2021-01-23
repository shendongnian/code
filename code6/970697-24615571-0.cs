    //Class Level
    List<TcpClient> connectedClients = List<TcpClient>();
    
    private async void Accept(TcpClient client)
    {
        connectedClients.Add(client);
        ...
    }
    
    public SendMessage(int index, String message)
    {
       //pseudo-code
       connectedClients[index].Send(message);
    }
