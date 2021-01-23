    [AcceptVerbs(Http.Get, Http.Head, Http.MkCol, Http.Post, Http.Put)]
    public async Task<HttpResponseMessage> Proxy()
    {
        var request = this.Request;
        
        var proxyUri = this.GetProxyUri(request.RequestUri);
        request.RequestUri = proxyUri;
        request.Headers.Host = proxyUri.Host;
        if (request.Method == HttpMethod.Get)
        {
            request.Content = null;
        }
        
        //todo: Clone all cookies with the domain set to the domain of the proxyUri. Remove the old cookies and add the clones.
        using (var client = new HttpClient())
        {
            //default is 60 seconds or so
            client.Timeout = TimeSpan.FromMinutes(5);
            
            return await client.SendAsync(request, HttpCompletionOption.ResponseContentRead);
        }    
    }
    private string _baseUri = "https://api.example.com/xyz/abc/";
    private Uri GetProxyUri(Uri originalUri)
    {
        var proxyUri = originalUri.AbsolutePath;
        var indexOfProxy = proxyUri.IndexOf("proxy/") + 6;
        var finalUri = _baseUri + proxyUri.Substring(indexOfProxy, proxyUri.Length - indexOfProxy);
        return new Uri(finalUri);
    }
