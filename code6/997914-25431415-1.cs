    class HttpClient : IDisposeable
    {
        private CancelationTokenSource _disposeCts;
    
        public HttpClient()
        {
            _disposeCts = new CancelationTokenSource();
        }
    
        public Task<SomeClass> GetAsync(string url)
        {
            return GetAsync(url, CancellationToken.None);
        }
        public Task<SomeClass> GetAsync(string url, CancelationToken token)
        {
            var combinedCts = CancellationTokenSource.CreateLinkedTokenSource(token, _disposeCts.Token);
            var tokenToUse = combinedCts.Token;
            //....
        }
    
        public void Dispose()
        {
            _disposeCts.Cancel();
        }
        //... A whole bunch of other stuff.
    }
