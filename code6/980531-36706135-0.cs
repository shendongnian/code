    private void ListenForIncomingHttpRequests()
    {
        AwaitNetworkAvailability();
        // create
        var serverSocket = 
            new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        // bind
        var localEndpoint = new IPEndPoint(IPAddress.Any, port: 12000);
        serverSocket.Bind(localEndpoint);
        // listen
        serverSocket.Listen(backlog: 25);
        while (true)
        {
            AwaitNetworkAvailability();
            try
            {
                // client connects to the server
                using (var clientSocket = serverSocket.Accept())
                {
                    ProcessServerSocketRequest(clientSocket);
                }
            }
            catch (Exception ex)
            {
                _logger.Write(ex.ToString());
            }
        }
    }
