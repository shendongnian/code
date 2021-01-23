    public class Server
    {
        private TcpListener _server;
        private bool _isServerWorking = false;
        private TcpClient _client;
        public Server(string host, int port)
        {
            var ipAddress = IPAddress.Parse(host);
            _server = new TcpListener(ipAddress, port);
        }
        public async Task StartAsync()
        {
            _server.Start();
            _isServerWorking = true;
            while(_isServerWorking)
            {
                _client = await _server.AcceptTcpClientAsync();
                ServerConnectedEventArgs args = new ServerConnectedEventArgs(_client);
                OnServerConnected(args);
                ThreadPool.QueueUserWorkItem(ConnectClientsThredProc, _client);
            }
        }
        public void Stop()
        {
            _isServerWorking = false;
            _server.Stop();
        }
        
        private static void ConnectClientsThredProc(object obj)
        {
            var client = (TcpClient)obj;
        }
        public event ServerConnectedEventHandler ServerConnectedEvent;
        private void OnServerConnected(ServerConnectedEventArgs e)
        {
            ServerConnectedEvent(this, e);
        }
    }
