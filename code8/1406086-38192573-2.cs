    public void Start()
    {
        _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        _clientSocket.BeginConnect(new IPEndPoint(IPAddress.Parse("192.168.5.150"), 3333), new AsyncCallback(ConnectCallback), null);
    }
    public void ConnectCallback(IASyncResult state)
    {
        // get the socket from the state etc.....
        AppendToTextBox("Connected!");
        clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(RecieveCallback), _clientSocket);
    }
    public void RecieveCallback(IASyncResult state)
    {
        // check if you receive the bytes you are trying to read.
    }
