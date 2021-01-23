    /// <summary>
    /// Asynchronous socket based network communication class
    /// </summary>
    public class ClientConnection
    {
        /// <summary>
        /// The data buffer size
        /// </summary>
        private const int _bufferSize = 1024;
        /// <summary>
        /// The socket
        /// </summary>
        private Socket socket = null;
        /// <summary>
        /// The event is raised when the client has connected.
        /// </summary>
        public event EventHandler Connected;
        /// <summary>
        /// Gets a value indicating whether this instance is connected.
        /// </summary>
        public bool IsConnected { get; private set; }
        /// <summary>
        /// Occurs when a server message has arrived.
        /// </summary>
        public event EventHandler<ServerMessageArgs> ServerMessageArrived;
        /// <summary>
        /// Connects to server asynchronous.
        /// </summary>
        /// <param name="serverInfo">The server information.</param>
        /// <returns>Returns an awaitable Task</returns>
        public void ConnectToServerAsync(string url, int port)
        {
            var endPoint = this.GetIPEndPointFromHostName(url, port, false);
            this.socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            this.socket.BeginConnect(endPoint, new AsyncCallback(this.ConnectedCallback), this.socket);
            this.IsConnected = true;
        }
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (this.socket.Connected)
            {
                this.socket.Disconnect(false);
            }
            this.socket.Dispose();
        }
        /// <summary>
        /// Sends the given message to the server.
        /// </summary>
        /// <param name="message">The message that the server will receive.</param>
        public void SendMessage(string message)
        {
            // Strip the ending carriage return and linefeed characters and re-add them
            // We do this in the event that only one out of the two were provided, or they 
            // came in out of order.
            message = $"{message.TrimEnd('\r', '\n')}\r\n";
            // Convert the string data to byte data using ASCII encoding.
            byte[] byteData = Encoding.UTF8.GetBytes(message);
            // Begin sending the data to the remote device.
            this.socket.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), this.socket);
        }
        /// <summary>
        /// The callback invoked when the sending of data to the server has completed.
        /// </summary>
        /// <param name="ar">The async operation result</param>
        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Complete sending the data to the remote device.
                int bytesSent = this.socket.EndSend(ar);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        /// <summary>
        /// The callback invoked when the client has connected to the server.
        /// </summary>
        /// <param name="result">The current async result.</param>
        private void ConnectedCallback(IAsyncResult result)
        {
            this.socket.EndConnect(result);
            var handler = this.Connected;
            if (handler == null)
            {
                return;
            }
            handler(this, new EventArgs());
            this.ReceiveData();
        }
        /// <summary>
        /// Handles starting the receive operation, listening for new data from the server.
        /// </summary>
        private void ReceiveData()
        {
            var buffer = new byte[_bufferSize];
            this.socket.BeginReceive(
                buffer,
                0,
                _bufferSize,
                0,
                new AsyncCallback(ReceiveCallback),
                buffer);
        }
        /// <summary>
        /// Handles processing the data received from the server.
        /// </summary>
        /// <param name="result"></param>
        private void ReceiveCallback(IAsyncResult result)
        {
            if (!this.IsConnected)
            {
                return;
            }
            byte[] buffer = (byte[])result.AsyncState;
            int bytesRead = this.socket.EndReceive(result);
            var contentBuilder = new StringBuilder();
            string content = string.Empty;
            if (bytesRead > 0)
            {
                // There might be more data, so store the data received so far.
                contentBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
                foreach (string message in contentBuilder.ToString().Split('\n'))
                {
                    this.OnServerMessageArrived(message);
                }
                //  Get the rest of the data.
                this.socket.BeginReceive(
                    (buffer = new byte[_bufferSize]),
                    0,
                    _bufferSize,
                    0,
                    new AsyncCallback(ReceiveCallback),
                    buffer);
            }
        }
        /// <summary>
        /// Called when a server message has arrived.
        /// </summary>
        /// <param name="content">The content.</param>
        private void OnServerMessageArrived(string content)
        {
            var handler = this.ServerMessageArrived;
            if (handler == null)
            {
                return;
            }
            handler(this, new ServerMessageArgs(content));
        }
        /// <summary>
        /// Gets the name of the ip end point from a given host name.
        /// </summary>
        /// <param name="hostName">Name of the host.</param>
        /// <param name="port">The port.</param>
        /// <param name="throwIfMoreThanOneIP">if set to <c>true</c> [throw if more than one ip].</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">
        /// Unable to retrieve address from specified host name.;hostName
        /// or
        /// There is more that one IP address to the specified host.;hostName
        /// </exception>
        private IPEndPoint GetIPEndPointFromHostName(string hostName, int port, bool throwIfMoreThanOneIP)
        {
            var addresses = Dns.GetHostAddresses(hostName);
            if (addresses.Length == 0)
            {
                throw new ArgumentException(
                    "Unable to retrieve address from specified host name.",
                    "hostName"
                );
            }
            else if (throwIfMoreThanOneIP && addresses.Length > 1)
            {
                throw new ArgumentException(
                    "There is more that one IP address to the specified host.",
                    "hostName"
                );
            }
            return new IPEndPoint(addresses[0], port); // Port gets validated here.
        }
    }
