    public class MyHttpClient
        : IMyHttpClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
    
        public SalesOrderHttpClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
    
        public async Task<string> PostAsync(Uri uri, string content)
        {
            using (var client = _httpClientFactory.Create())
            {
                var clientAddress = uri.GetLeftPart(UriPartial.Authority);
                client.BaseAddress = new Uri(clientAddress);
                var content = new StringContent(content, Encoding.UTF8, "application/json");
                var uriAbsolutePath = uri.AbsolutePath;
                var response = await client.PostAsync(uriAbsolutePath, content);
                var responseJson = response.Content.ReadAsStringAsync().Result;
                return responseJson;
            }
        }
    }
