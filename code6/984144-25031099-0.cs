    public async Task<HttpResponseMessage> MakeRequestAsync(HttpRequestMessage request)
    {            
        //Wait while the limit has been reached. 
        while(!_throttlingHelper.RequestAllowed) 
        {
          await Task.Delay(1000);
        }
    
        var client = new HttpClient();
        _throttlingHelper.StartRequest();
        var result = await client.SendAsync(request).ConfigureAwait(false);
        _throttlingHelper.EndRequest();
        return result; 
    }
