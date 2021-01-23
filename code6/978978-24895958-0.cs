    public static CookieContainer cookies = new CookieContainer();
     var handler = new HttpClientHandler
                {
                    CookieContainer = cookies,
                    UseCookies = true,
                    UseDefaultCredentials = false
                };
              
               
    
                HttpClient htclient = new HttpClient(handler);
