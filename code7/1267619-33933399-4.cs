    public static class HttpClientFactory
        {
            public static HttpClient GetClient()
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:1431");
    
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
    
                return client;
            }
        }
