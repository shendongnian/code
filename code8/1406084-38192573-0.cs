    _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    _clientSocket.BeginConnect(new IPEndPoint(IPAddress.Parse("192.168.5.150"), 3333), new AsyncCallback(ConnectCallback), null);
    // you cannot call BeginReceive on a NOT connected (yet) socket. You must move the `BeginReceive` to the `ConnectCallback` method
    _clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(RecieveCallback), _clientSocket);
    // You're NOT connected here.. You might be connected when the `ConnectCallback` is executed.
    AppendToTextBox("Connected!");
