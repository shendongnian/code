    private const int _maxParallelRequest = 10;
    private int _requestCount = 0;
    private readonly object _sync = new object();
    private ManualResetEvent _ev = new ManualResetEvent(false);
    while(true)
    {
        foreach (var uri in _allYourUris)
        {
            var wait = false;
            lock (_sync)
            {
                if (_requestCount >= _maxParallelRequest)
                    wait = true;
            }
            if (!wait)
            {
                lock (_sync) { ++_requestCount; }
                RunRequest(uri, r => {
                    lock (_sync) 
                    { 
                        --_requestCount; 
                        _ev.Set();
                    }    
                    // handle r
                });
                continue;
            }
            _ev.WaitOne();
        }
        Thread.Sleep(3000);
    }
    
