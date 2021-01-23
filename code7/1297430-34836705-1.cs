    private Socket _socket;
        private CheckRegisteredRequest computer_name;
        private bool isClosed;
        private byte[] _buffer;
        public delegate void RaiseConnect(object source, TextArgs e);
        public static event EventHandler Disconnected;
        private static void RaiseDisconnect()
        {
            EventHandler handler = Disconnected;
            if (handler != null)
            {
                handler(null, EventArgs.Empty);
            }
        }
        public ClientSocket()
        {
            isClosed = true;
            udpbroadcast.Connect += new RaiseConnect(OnConnectRaise);
            computer_name = new CheckRegisteredRequest(Environment.MachineName.ToString() + "," + machineIP());
        }
        private void OnConnectRaise(object sender, TextArgs e)
        {
            if(!isClosed)
            {
                _socket.Close();
                Connect(e.Message, 6556);
            }
            else
            {
                Connect(e.Message, 6556);
            }
        }
        public void Connect(string ipAddress, int port)
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _socket.BeginConnect(new IPEndPoint(IPAddress.Parse(ipAddress), port), ConnectCallback, null);
            isClosed = false;
            /*IAsyncResult result = 
            bool success = result.AsyncWaitHandle.WaitOne(5000, true);
            if (!success)
            {
                _socket.Shutdown(SocketShutdown.Both);
                _socket.Close();
                Console.WriteLine("Failed to connect to server. Trying again.");
                RaiseDisconnect();
            }*/
        }
        private void ConnectCallback(IAsyncResult result)
        {
            try
            {
                if(_socket.Connected)
                {
                    _socket.EndConnect(result);
                    Console.WriteLine("We initiated a connection to the server.");
                    Console.WriteLine("Connected to the server!");
                    Send(computer_name.Data);
                    _buffer = new byte[61144];
                    _socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceivedCallback, null);
                }
                else
                {
                    Console.WriteLine("Could not connect.");
                    if(!isClosed)
                    {
                        _socket.Close();
                        isClosed = true;
                        RaiseDisconnect();
                    }
                    else
                    {
                        isClosed = true;
                        RaiseDisconnect();
                    }
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine("ConnectCallback Exception Caught.");
                Console.WriteLine("Shutting down and closing socket for reusal.");
                if (!isClosed)
                {
                    _socket.Close();
                    isClosed = true;
                    RaiseDisconnect();
                }
                else
                {
                    isClosed = true;
                    RaiseDisconnect();
                }
            }
        }
        private void ReceivedCallback(IAsyncResult result)
        {
            try
            {
                SocketError SE;
                int buflength = _socket.EndReceive(result, out SE);
                if (SE == SocketError.Success)
                {
                    byte[] packet = new byte[buflength];
                    Array.Copy(_buffer, packet, packet.Length);
                    //Handle the Package
                    PacketHandler.Handle(packet, _socket);
                    _buffer = new byte[61144];
                    //_socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceivedCallback, null);
                    _socket.BeginReceive(new byte[] { 0 }, 0, 0, 0, ReceivedCallback, null);
                }
                else
                {
                    Console.WriteLine("No bytes received, we're closing the connection.");
                    if (!isClosed)
                    {
                        _socket.Close();
                        isClosed = true;
                        RaiseDisconnect();
                    }
                    else
                    {
                        isClosed = true;
                        RaiseDisconnect();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ReceivedCallback Exception Caught.");
                Console.WriteLine("Shutting down and closing socket for reusal.");
                if (!isClosed)
                {
                    _socket.Close();
                    isClosed = true;
                    RaiseDisconnect();
                }
                else
                {
                    isClosed = true;
                    RaiseDisconnect();
                }
            }
        }
        public void Send(byte[] data)
        {
            byte[] send = new byte[data.Length];
            send = data;
            if (_socket.Connected)
            {
                _socket.Send(data);
            }
            else
            {
                Console.WriteLine("We're not connected yet!");
                if (!isClosed)
                {
                    _socket.Close();
                    isClosed = true;
                    RaiseDisconnect();
                }
                else
                {
                    isClosed = true;
                    RaiseDisconnect();
                }
            }
        }
        public bool connectionStatus()
        {
            return _socket.Connected;
        }
        public string machineIP()
        {
            return Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork).ToString();
        }
