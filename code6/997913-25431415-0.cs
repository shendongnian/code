    class HttpClient : IDisposeable
    {
        private CancelationTokenSource _cts;
    
        public HttpClient()
        {
            _cts = new CancelationTokenSource();
        }
    
        public async Task<SomeClass> GetAsync(string url)
        {
            return SomeOtherInternalFunctionAsync(url, _cts.Token);
        }
    
        public void Dispose()
        {
            _cts.Cancel();
        }
        //... A whole bunch of other stuff.
    }
