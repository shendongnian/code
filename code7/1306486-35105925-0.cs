    public var connectedClients = new list<TcpClient>();
    
    public void ConnectClient(int ip, int port)
        {
            tcp.Connect(ip, port);
            connectedClients.Add(tcp);
        }
