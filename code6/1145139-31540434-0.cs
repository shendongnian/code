        public static string GetCookie()
        {
            WebRequest request = WebRequest.Create("https://hornystress.me");
            request.Proxy = WebProxy.GetDefaultProxy();
            request.Timeout *= 100;
            string cookie;
             WebResponse response;
            try
            {
              response  = request.GetResponse();
              cookie = response.Headers.Get("Set-Cookie");
            }
            catch (WebException we)
            {
               cookie=we.Response.Headers.Get("Set-Cookie");
            }
            return cookie;
        }
    
