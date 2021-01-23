    static void ConnectionAccepted(IAsyncResult IAr)
    {
        Connection UserConnection = new Connection(MainSocket.EndAccept(IAr));
        MainSocket.BeginAccept(ConnectionAccepted, MainSocket);
    }
