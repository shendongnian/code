    public void Start()
    {
        // init _host ...
        _syncContext = SynchronizationContext.Current;
        _host.Start();
    }
    public void Stop()
    {
        if (_syncContext == SynchronizationContext.Current)
        {
            _host.Dispose();
        }
        else
        {
            _syncContext.Post((state) =>
            {
                _host.Dispose();
            }
            , null);
        }
    }
