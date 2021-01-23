    private class RequestHandler
    {
        private EventWaitHandle _handle;
        public RequestHandler(Func<string> request)
        {
            _handle = new EventWaitHandle(false, EventResetMode.ManualReset);
            Start(request);
        }
        private void Start(Func<string> doRequest)
        {
            Result = doRequest();
            _handle.Set();
        }
        public void WaitForResponse()
        {
            _handle.WaitOne();
        }
        public string Result { get; private set; }
    }
    private Object _lockObject = new Object();
    private Dictionary<string, RequestHandler> _pendingRequests = new Dictionary<string, RequestHandler>();
    public string GetCustomer(int id)
    {
        RequestHandler request;
        lock (_lockObject)
        {
            if (!_pendingRequests.TryGetValue(id, out request))
            {
                request = new RequestHandler(() => LoadEntity(id));
                _pendingRequests[id] = request;
            }
        }
        request.WaitForResponse();
        lock (_lockObject)
        {
            _pendingRequests.Clear();
        }
        return request.Result;
    }
