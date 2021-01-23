    public HttpRequestMessage CreateRequest(string url)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("Authorization", "Bearer " + GetUpToDateAccessToken()); 
        return request;
    }
    
    private Token GetUpToDateAccessToken()
    {
        _readWriteLockSlim.EnterReadLock();
        try
        {      
            return _latestToken;
        }
        finally
        {
            _readWriteLockSlim.ExitReadLock();
        }  
    }
