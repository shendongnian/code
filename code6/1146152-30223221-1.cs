    class UdpListener : IDisposable
    {
        private bool _isDisposed;
        private IAsyncResult _asyncResult;
        private readonly IPAddress _hostIpAddress;
        private readonly int _port;
        private UdpClient _udpClient;
        public UdpListener(IPAddress hostIpAddress, int port)
        {
            _hostIpAddress = hostIpAddress;
            _port = port;
        }
        public void Start()
        {
           if (_asyncResult == null)
           {
               _udpClient.Connect(_hostIpAddress, _port);
               _asyncResult = _udpClient.BeginReceive(HandleMessage, null);
           }
        }
        public void Dispose()
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException("UdpListener");
            }
            _updClient.Close();
            if (_asyncResult != null)
            {
                try 
                {
                    IPEndPoint remoteEP = null;
                    _updClient.EndReceive(_asyncResult, ref remoteEP);
                }
                catch (ObjectDisposedException) { /* expected */ }
            } 
            ((IDisposable)_udpClient).Dispose();
            _isDisposed = true;
        }
        private static void HandleMessage(IAsyncResult asyncResult)
        {
            // handle...
        }
    }
