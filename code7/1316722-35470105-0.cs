    public async void testcallwind()
        {
            List<HttpCookie> cookieCollection = new List<HttpCookie>();
            HttpBaseProtocolFilter filter = new HttpBaseProtocolFilter();
            HttpClient httpClient;
            filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.Untrusted);//Allow untrusted CA's 
            filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.Expired);
            // add known cookies to request (needed for authentication)
            foreach (HttpCookie knownCookie in cookieCollection)
            {
                filter.CookieManager.SetCookie(knownCookie);
            }
            httpClient = new HttpClient(filter);
            string resourceAddress = string.Format("https://...");
            string requestString = "{\"request\":{\"CallerState\":null,...."}}";
            byte[] requestData = Encoding.UTF8.GetBytes(requestString);        
            UnicodeEncoding en = new UnicodeEncoding();
            
            IHttpContent content = new HttpStringContent(requestString, 0, "application/json");
            Uri postBody = new Uri(resourceAddress);            
    
            var response = await httpClient.PostAsync(postBody, content);
            httpClient.Dispose();
            var test = response.Content;
        }
