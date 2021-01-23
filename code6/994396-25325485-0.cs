    public static class HttpClientFactory
    {
        private static HttpClient httpClient;
        public static HttpClient Create()
        {
            if (httpClient == null)
            {
                var baseAddress = new Uri("http://localhost:8081");
                var configuration = new HttpSelfHostConfiguration(baseAddress);
                var selfHostServer = new HttpSelfHostServer(configuration);
                
                httpClient = new HttpClient(selfHostServer) {BaseAddress = baseAddress};
               
                return httpClient;
            }
            return httpClient;
        }
    }
    }
