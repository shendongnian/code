    public class UdpListener : IDisposable
    {
        private readonly IPAddress _hostIpAddress;
        private readonly int _port;
        private readonly Action<UdpReceiveResult> _processor;
        private TaskCompletionSource<bool> _tcs = new TaskCompletionSource<bool>();
        private CancellationTokenSource _tokenSource = new CancellationTokenSource();
        private CancellationTokenRegistration _tokenReg;
        private UdpClient _udpClient;
        public UdpListener(IPAddress hostIpAddress, int port, Action<UdpReceiveResult> processor)
        {
            _hostIpAddress = hostIpAddress;
            _port = port;
            _processor = processor;
        }
        public Task ReceiveAsync()
        {
            // note: there is a race condition here in case of concurrent calls 
            if (_tokenSource != null && _udpClient == null)
            {
                try 
                {
                    _udpClient = new UdpClient();
                    _udpClient.Connect(_hostIpAddress, _port);
                    _tokenReg = _tokenSource.Token.Register(() => _udpClient.Close());
                    BeginReceive();
                }
                catch (Exception ex)
                {
                    _tcs.SetException(ex);
                    throw;
                }
            }
            return _tcs.Task;
        }
        public void Stop()
        {
            var cts = Interlocked.Exchange(ref _tokenSource, null);
            if (cts != null)
            {
                cts.Cancel();
                if (_tcs != null && _udpClient != null)
                    _tcs.Task.Wait();
                _tokenReg.Dispose();
                cts.Dispose();
            }
        }
        public void Dispose()
        {
            Stop();
            if (_udpClient != null) 
            {
                ((IDisposable)_udpClient).Dispose();
                _udpClient = null;
            }
            GC.SuppressFinalize(this);
        }
        private void BeginReceive()
        {
            var iar = _udpClient.BeginReceive(HandleMessage, null);
            if (iar.CompletedSynchronously)
                HandleMessage(iar); // if "always" completed sync => stack overflow
        }
        private void HandleMessage(IAsyncResult iar)
        {
            try
            {
                IPEndPoint remoteEP = null;
                Byte[] buffer = _udpClient.EndReceive(iar, ref remoteEP);
                _processor(new UdpReceiveResult(buffer, remoteEP));
                BeginReceive(); // do the next one
            }
            catch (ObjectDisposedException)
            {
                // we were canceled, i.e. completed normally
                _tcs.SetResult(true);
            }
            catch (Exception ex)
            {
                // we failed.
                _tcs.TrySetException(ex); 
            }
        }
    }
