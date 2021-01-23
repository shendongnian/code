    class HttpClient : IDisposeable
    {
        private CancelationTokenSource _disposeCts;
    
        public HttpClient()
        {
            _disposeCts = new CancelationTokenSource();
        }
    
        public Task<HttpResponseMessage> GetAsync(string url)
        {
            return GetAsync(url, CancellationToken.None);
        }
        public async Task<HttpResponseMessage> GetAsync(string url, CancelationToken token)
        {
            var combinedCts = CancellationTokenSource.CreateLinkedTokenSource(token, _disposeCts.Token);
            var tokenToUse = combinedCts.Token;
            //... snipped code
            //Some spot where it would good to check if we have canceled yet.
            tokenToUse.ThrowIfCancellationRequested();
            //... More snipped code;
             
            return result;
        }
    
        public void Dispose()
        {
            _disposeCts.Cancel();
        }
        //... A whole bunch of other stuff.
    }
