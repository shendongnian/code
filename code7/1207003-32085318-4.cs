    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class Service1 : IService1
    {
        private static List<KeyValuePair<string, IService1DuplexCallback>> _clients = new List<KeyValuePair<string, IService1DuplexCallback>>();
        private static bool _isProcessStarted;
        private string _sessionStarted = string.Empty;
    
        public void Subscribe(string idSesion)
        {
            lock (_clients)
            {
                if (!_clients.Any(x => string.Equals(x.Key, idSesion, StringComparison.InvariantCultureIgnoreCase)))
                {
                    var callback = OperationContext.Current.GetCallbackChannel<IService1DuplexCallback>();
    
                    if (callback != null)
                    {
                        var currentSubscriber = new KeyValuePair<string, IService1DuplexCallback>(idSesion, callback);
                        _clients.Add(currentSubscriber);
                    }
                }
            }
    
            if (_isProcessStarted)
            {
                NotifyProcessWorking(idSesion);
            }
        }
    
        public void ProcessFiles(string idSesion)
        {
            _isProcessStarted = true;
            _sessionStarted = idSesion;
    
            try
            {
                var mockFileCount = 2;
                var r = new Random();
    
                NotifyStarted();
                NotifyProcessWorking();
    
                Parallel.For(0, mockFileCount, (i) =>
                {
                    //Do a lot of specific validations... (time betweeen 5 secs and 2 minutes per file)
                    var time = 5000;//r.Next(5000, 120000);
    
                    Thread.Sleep(time);
    
                    NotifyFileProcessed(i);
                });
    
                NotifyProcessFinished();
            }
            catch (Exception ex)
            {
                throw;
            }
    
            _isProcessStarted = false;
        }
    
        private void NotifyStarted()
        {
            var c = _clients.FirstOrDefault(x => string.Equals(x.Key, _sessionStarted, StringComparison.InvariantCultureIgnoreCase));
    
            try
            {
                c.Value.NotifyProcessStarted();
            }
            catch (Exception ex)
            {
                lock (_clients)
                {
                    _clients.Remove(c);
                }
            }
        }
    
        private void NotifyFileProcessed(int idFile)
        {
            var c = _clients.FirstOrDefault(
                x => string.Equals(x.Key, _sessionStarted,
                StringComparison.InvariantCultureIgnoreCase)
                );
    
            try
            {
                c.Value.NotifyFileProcessed(idFile);
            }
            catch (Exception ex)
            {
                lock (_clients)
                {
                    _clients.Remove(c);
                }
            }
        }
    
        private void NotifyProcessFinished()
        {
            //STILL SAME YOU HAVE IT. JUST IN CASE
            foreach (var c in _clients)
            {
                try
                {
                    c.Value.NotifyProcessFinished();
                }
                catch (Exception ex)
                {
                    lock (_clients)
                    {
                        _clients.Remove(c);
                    }
                }
            }
        }
    
        private static void NotifyProcessWorking(string idSesion = "")
        {
            if (string.IsNullOrEmpty(idSesion))
            {
                foreach (var c in _clients)
                {
                    try
                    {
                        c.Value.NotifyProcessWorking();
                    }
                    catch (Exception ex)
                    {
                        lock (_clients)
                        {
                            _clients.Remove(c);
                        }
                    }
                }
            }
            else
            {
                var c = _clients.FirstOrDefault(x => string.Equals(x.Key, idSesion, StringComparison.InvariantCultureIgnoreCase));
    
                try
                {
                    c.Value.NotifyProcessWorking();
                }
                catch (Exception)
                {
                    lock (_clients)
                    {
                        _clients.Remove(c);
                    }
                }
            }
        }
    }
