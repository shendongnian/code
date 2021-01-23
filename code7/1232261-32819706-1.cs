    public class Session : IDisposible
    {
        private HttpClient m_httpClient;
    
        public Session()
        {
           m_httpClient = new HttpClient();
        }
    
        public void Dispose()
        {
           m_httpClient.Dispose();
        }
    }
