    public class Connection
    {
        private IHttpClient _httpClient;
    
        public Connection(IHttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
