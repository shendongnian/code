        private Socket _socket;
        Byte[] _buffer = new byte[61144];
        public ServerSocket()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        public void Bind(int port)
        {
            _socket.Bind(new IPEndPoint(IPAddress.Any, port));
        }
        public void Listener(int backlog)
        {
            _socket.Listen(backlog);
        }
        public void Accept()
        {
            _socket.BeginAccept(AcceptedCallback, null);
        }
        private void AcceptedCallback(IAsyncResult result)
        {
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                Console.WriteLine("We accepted a connection.");
                clientSocket = _socket.EndAccept(result);
                if (clientSocket.Connected)
                {
                    Console.WriteLine("Client has connected!");
                    _buffer = new byte[61144];
                    //clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceivedCallback, clientSocket);
                    clientSocket.BeginReceive(new byte[] {0}, 0, 0, 0, ReceivedCallback, clientSocket);
                    Accept();
                }
                else
                {
                    Console.WriteLine("Client hasn't connected!");
                    Accept();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Socket was probably forcefully closed." + ex.Message);
                Console.WriteLine("Continue accepting other connections.");
                clientSocket.Close();
                Accept();
            }
        }
        private void ReceivedCallback(IAsyncResult result)
        {
            Socket clientSocket = result.AsyncState as Socket;
            SocketError ER;
            try
            {
                int bufferSize = clientSocket.EndReceive(result, out ER);
                if (ER == SocketError.Success)
                {
                    byte[] packet = new byte[bufferSize];
                    Array.Copy(_buffer, packet, packet.Length);
                    Console.WriteLine("Handling packet from IP:" + clientSocket.RemoteEndPoint.ToString());
                    //Handle packet stuff here.
                    PacketHandler.Handle(packet, clientSocket);
                    _buffer = new byte[61144];
                    clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceivedCallback, clientSocket);
                    //clientSocket.BeginReceive(new byte[] { 0 }, 0, 0, 0, ReceivedCallback, clientSocket);
                }
                else
                {
                    Console.WriteLine("No bytes received, we're closing the connection.");
                    clientSocket.Close();
                }
            }catch(SocketException ex)
            {
                Console.WriteLine("We caught a socket exception:" + ex.Message);
                clientSocket.Close();
            }
        }
