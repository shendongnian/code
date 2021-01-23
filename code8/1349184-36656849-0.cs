    class ClientReceiveThread
    {
        public Thread T { get; set; }
        public ClientReceiveThread(Socket ClientSocket, Socket ServerSocket)
        {
            T = new Thread(() =>
            {
                try
                {               
                    byte[] buf = new byte[1024];
                    while (ClientSocket.Receive(buf) > 0)
                    {
                        // Received data from the game client
                        Packet p = new Packet(buf);
                        Logger.Log(p.ID, LogType.PACKET);
                        // Forward re-encrypted data back to the official server
                        ServerSocket.Send(p.Encrypt());
                    }
                }
                catch (Exception e)
                {
                    ExceptionHandler.Handle(e);
                }
            });
            T.Start();
        }
    }
    
    class ServerReceiveThread
    {
        public Thread T { get; set; }
        public ServerReceiveThread(Socket ClientSocket, Socket ServerSocket)
        {
            T = new Thread(() =>
            {
                try
                {
                    byte[] buf = new byte[1024];
                    while (ServerSocket.Receive(buf) > 0)
                    {
                        // Received Data from the official server
                        Packet p = new Packet(buf);
                        Logger.Log(p.ID, LogType.PACKET);
                        // Forward re-encrypted data back to the game client
                        ClientSocket.Send(p.Encrypt());
                    }
                }
                catch (Exception e)
                {
                    ExceptionHandler.Handle(e);
                }
            });
            T.Start();
        }
    }
