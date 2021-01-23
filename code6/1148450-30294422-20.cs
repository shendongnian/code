    /// <summary>
    /// The Default Desktop game Server
    /// </summary>
    public sealed class Server
    {
        /// <summary>
        /// The user connection buffer size
        /// </summary>
        private const int UserConnectionBufferSize = 1024;
        /// <summary>
        /// The server socket
        /// </summary>
        private Socket serverSocket;
        /// <summary>
        /// The player connections
        /// </summary>
        private List<ConnectionState> connectedClients;
        /// <summary>
        /// Used for making access to the connectedClients collection thread-safe
        /// </summary>
        private object lockObject = new object();
        /// <summary>
        /// Initializes a new instance of the <see cref="Server"/> class.
        /// </summary>
        public Server()
        {
            this.Status = ServerStatus.Stopped;
            this.connectedClients = new List<ConnectionState>();
        }
        /// <summary>
        /// Occurs when a client connects to the server.
        /// </summary>
        public event EventHandler<ConnectedArgs> ClientConnected;
        /// <summary>
        /// Occurs when a client is disconnected from the server.
        /// </summary>
        public event EventHandler<ConnectedArgs> ClientDisconnected;
        /// <summary>
        /// Gets or sets the port that the server is running on.
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// Gets or sets the maximum queued connections.
        /// </summary>
        public int MaxQueuedConnections { get; set; }
        /// <summary>
        /// Gets the current server status.
        /// </summary>
        public ServerStatus Status { get; private set; }
        public void Start()
        {
            if (this.Status != ServerStatus.Stopped)
            {
                throw new InvalidOperationException("The server is either starting or already running. You must stop the server before starting it again.");
            }
            else if (this.Port == 0)
            {
                throw new InvalidOperationException("You can not start the server on Port 0.");
            }
            this.Status = ServerStatus.Starting;
            
            // Get our server address information
            IPHostEntry serverHost = Dns.GetHostEntry(Dns.GetHostName());
            var serverEndPoint = new IPEndPoint(IPAddress.Any, this.Port);
            // Instance the server socket, bind it to a port.
            this.serverSocket = new Socket(serverEndPoint.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            this.serverSocket.Bind(serverEndPoint);
            this.serverSocket.Listen(this.MaxQueuedConnections);
            // Begin listening for connections.
            this.serverSocket.BeginAccept(new AsyncCallback(this.ConnectClient), this.serverSocket);
            this.Status = ServerStatus.Running;
        }
        /// <summary>
        /// Stops the server.
        /// </summary>
        public void Stop()
        {
            this.DisconnectAll();
            // We test to ensure the server socket is still connected and active.
            this.serverSocket.Blocking = false;
            try
            {
                this.serverSocket.Send(new byte[1], 0, 0);
                // Message was received meaning it's still receiving, so we can safely shut it down.
                this.serverSocket.Shutdown(SocketShutdown.Both);
            }
            catch (SocketException e)
            {
                // Error code 10035 indicates it works, but will block the socket.
                // This means it is still receiving and we can safely shut it down.
                // Otherwise, it's not receiving anything and we don't need to shut down.
                if (e.NativeErrorCode.Equals(10035))
                {
                    this.serverSocket.Shutdown(SocketShutdown.Both);
                }
            }
            finally
            {
                this.Status = ServerStatus.Stopped;
            }
        }
        /// <summary>
        /// Disconnects the specified IServerPlayer object.
        /// </summary>
        /// <param name="connection">The client to disconnect.</param>
        public void Disconnect(ConnectionState connection)
        {
            if (connection != null && connection.IsConnectionValid)
            {
                connection.CurrentSocket.Shutdown(SocketShutdown.Both);
                this.connectedClients.Remove(connection);
                this.OnClientDisconnected(connection);
            }
        }
        /// <summary>
        /// Disconnects everyone from the server.
        /// </summary>
        public void DisconnectAll()
        {
            // Loop through each connection and disconnect them.
            foreach (ConnectionState state in this.connectedClients)
            {
                Socket connection = state.CurrentSocket;
                if (connection != null && connection.Connected)
                {
                    connection.Shutdown(SocketShutdown.Both);
                    this.OnClientDisconnected(state);
                }
            }
            this.connectedClients.Clear();
        }
        /// <summary>
        /// Called when a client connects.
        /// </summary>
        private void OnClientConnected(ConnectionState connection)
        {
            EventHandler<ConnectedArgs> handler = this.ClientConnected;
            if (handler == null)
            {
                return;
            }
            handler(this, new ConnectedArgs(connection));
        }
        /// <summary>
        /// Called when a client disconnects.
        /// </summary>
        private void OnClientDisconnected(ConnectionState connection)
        {
            EventHandler<ConnectedArgs> handler = this.ClientDisconnected;
            if (handler == null)
            {
                return;
            }
            handler(this, new ConnectedArgs(connection));
        }
        /// <summary>
        /// Connects the client to the server and then passes the connection responsibilities to the client object.
        /// </summary>
        /// <param name="result">The async result.</param>
        private void ConnectClient(IAsyncResult result)
        {
            // Connect and register for network related events.
            Socket connection = this.serverSocket.EndAccept(result);
            // Send our greeting
            byte[] buffer = Encoding.ASCII.GetBytes("Welcome to the Music App Server!");
            connection.BeginSend(buffer, 0, buffer.Length, 0, new AsyncCallback(asyncResult => connection.EndReceive(asyncResult)), null);
            // Fetch the next incoming connection.
            this.serverSocket.BeginAccept(new AsyncCallback(this.ConnectClient), this.serverSocket);
            
            this.CompleteClientSetup(new ConnectionState(connection, UserConnectionBufferSize));
        }
        /// <summary>
        /// Caches the ConnectionState and has the state begin listening to client data.
        /// </summary>
        /// <param name="connectionState"></param>
        private void CompleteClientSetup(ConnectionState connectionState)
        {
            lock (this.lockObject)
            {
                this.connectedClients.Add(connectionState);
            }
            // Start receiving data from the client.
            connectionState.StartListeningForData();
            this.OnClientConnected(connectionState);
        }
    }
