    private byte[] dataStream = new byte[1024];
    private Socket serverSocket;
    private void InitializeSocketServer(string id)
    {
        // Sets the server ID
        this._id = id;
        // Initialise the socket
        serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        // Initialise the IPEndPoint for the server and listen on port 30000
        IPEndPoint server = new IPEndPoint(IPAddress.Any, 30000);
        // Associate the socket with this IP address and port
        serverSocket.Bind(server);
        // Initialise the IPEndPoint for the clients
        IPEndPoint clients = new IPEndPoint(IPAddress.Any, 0);
        // Initialise the EndPoint for the clients
        EndPoint epSender = (EndPoint)clients;
        // Start listening for incoming data
        serverSocket.BeginReceiveFrom(this.dataStream, 0, this.dataStream.Length, SocketFlags.None, ref epSender, new AsyncCallback(ReceiveData), epSender);
    }
    private void ReceiveData(IAsyncResult asyncResult)
    {
        // Initialise the IPEndPoint for the clients
        IPEndPoint clients = new IPEndPoint(IPAddress.Any, 0);
        // Initialise the EndPoint for the clients
        EndPoint epSender = (EndPoint)clients;
        // Receive all data. Sets epSender to the address of the caller
        serverSocket.EndReceiveFrom(asyncResult, ref epSender);
        // Get the message received
        string message = Encoding.UTF8.GetString(dataStream);
        // Check if it is a search ws message
        if (message.StartsWith("SEARCHWS", StringComparison.CurrentCultureIgnoreCase))
        {
            // Create a response messagem indicating the server ID and it's URL
            byte[] data = Encoding.UTF8.GetBytes($"WSRESPONSE;{this._id};http://{GetIPAddress()}:5055/wsserver");
            // Send the response message to the client who was searching
            serverSocket.BeginSendTo(data, 0, data.Length, SocketFlags.None, epSender, new AsyncCallback(this.SendData), epSender);
        }
        // Listen for more connections again...
        serverSocket.BeginReceiveFrom(this.dataStream, 0, this.dataStream.Length, SocketFlags.None, ref epSender, new AsyncCallback(this.ReceiveData), epSender);
    }
    private void SendData(IAsyncResult asyncResult)
    {
        serverSocket.EndSend(asyncResult);
    }
