        public class TestHttpClientFactory : IHttpClientFactory 
    {
        public HttpClient CreateClient(string name)
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(G.Config.Get<string>($"App:Endpoints:{name}"))
                // G.Config is our singleton config access, so the endpoint 
                // to the running wiremock is used in the test
            };
            return httpClient;
        }
    }
