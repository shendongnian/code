    private HttpWebResponse Builder(string url, string host, NameValueCollection cookies)
    {
        HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
        request.Method = WebRequestMethods.Http.Get;
        request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
        // _request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip,deflate,sdch");
        request.Headers.Set(HttpRequestHeader.AcceptLanguage, "en-US,en;q=0.8");
        request.Headers.Set(HttpRequestHeader.CacheControl, "max-age=0");
    
        request.Host = host;
        request.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.146 Safari/537.36";
    
        request.CookieContainer = cookiecontainer;
    
        if (cookies != null)
        {
            foreach (var cookiekey in cookies.AllKeys)
            {
                request.CookieContainer.Add(
                    new Cookie(
                        cookiekey, 
                        cookies[cookiekey],
                        @"/",
                        host));    
            }
        }
        return (HttpWebResponse) request.GetResponse();
    }
