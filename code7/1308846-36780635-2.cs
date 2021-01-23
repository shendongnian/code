    class Listener {
        // we don't use cancellation tokens because AcceptTcpClientAsync does not support them anyway
        private volatile bool _shutdown;
        private TcpListener _listener;
        public async Task Start() {
            _listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 10010);
            _listener.ExclusiveAddressUse = false;
            _listener.Start();
            while (!_shutdown) {
                TcpClient client = null;
                try {
                    client = await _listener.AcceptTcpClientAsync();
                }
                catch (ObjectDisposedException) {
                    // will be thrown when you stop listener   
                }
                if (client != null) {
                    var tcpConnectedLogic = new TcpConnectionLogic(client);
                    // start processing on thread pool thread if necessary
                    // don't wait for it to finish - you need to accept more connections
                    tcpConnectedLogic.StartAsync();
                }
            }
        }
        public void Stop() {
            _shutdown = true;
            _listener.Stop();
        }
    }
