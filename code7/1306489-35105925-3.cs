    public void DisconnectClient(int ip, int port)
        {
            tcp.Close();
            connectedClients.RemoveRange(0, connectedClients.Length)
        }
