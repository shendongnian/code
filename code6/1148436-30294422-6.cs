    public class ClientConnection : IDisposable
    {
        private const int _bufferSize = 1024;
        private Socket socket = null;
        public event EventHandler Connected;
        public event EventHandler<ServerMessageArgs> ServerMessageArrived;
        public bool IsConnected { get; private set; }
        public void ConnectToServerAsync(string url, int port)
        {
            var endPoint = this.GetIPEndPointFromHostName(url, port, false);
            this.socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            this.socket.BeginConnect(endPoint, new AsyncCallback(this.ConnectedCallback), this.socket);
            this.IsConnected = true;
        }
        public void Dispose()
        {
            if (this.socket.Connected)
            {
                this.socket.Disconnect(false);
            }
            this.socket.Dispose();
        }
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
        private void OnServerMessageArrived(string content)
        {
            var handler = this.ServerMessageArrived;
            if (handler == null)
            {
                return;
            }
            handler(this, new ServerMessageArgs(content));
        }
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
