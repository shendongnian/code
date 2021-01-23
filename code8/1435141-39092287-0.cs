    public void Start()
        {
            IPEndPoint endp = new IPEndPoint(IPAddress.Parse(IP), port);
            try
            {
                socketClient = new Socket(endp, SocketType.Stream, ProtocolType.Tcp);
                socketClient.BeginConnect(endp, new AsyncCallback(ConnectCALLBACK), socketClient);
                Receive(socketClient);
            }
            catch
            {
    
            }
        }
