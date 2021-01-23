    public class HttpClientFactory
        : IHttpClientFactory
    {
        public HttpClient Create()
        {
            var httpClient = new HttpClient();
            return httpClient;
        }
    }
