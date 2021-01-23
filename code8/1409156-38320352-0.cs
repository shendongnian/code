    private class RequestHandler
    {
        private EventWaitHandle _handle;
        public RequestHandler(Func<TEntity> request)
        {
            _handle = new EventWaitHandle(false, EventResetMode.ManualReset);
            Start(request);
        }
        private void Start(Func<TEntity> doRequest)
        {
            Entity = doRequest();
            _handle.Set();
        }
        public void WaitForResponse()
        {
            _handle.WaitOne();
        }
        public TEntity Entity { get; private set; }
    }
    private Object _lockObject = new Object();
    private Dictionary<string, RequestHandler> _pendingRequests = new Dictionary<string, RequestHandler>();
    public string GetCustomer(int id)
    {
        RequestHandler request;
        lock (_lockObject)
        {
            if (!_pendingRequests.TryGetValue(identifier, out request))
            {
                request = new RequestHandler(() => LoadEntity(identifier));
                _pendingRequests[identifier] = request;
            }
        }
        request.WaitForResponse();
        lock (_lockObject)
        {
            _pendingRequests.Clear();
        }
        return request.Entity;
    }
