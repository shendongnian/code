    public class TestFixture<TStartup> : IDisposable where TStartup : class  
    {
        private readonly TestServer _server;
    
        public TestFixture()
        {
            var builder = new WebHostBuilder().UseStartup<TStartup>();
            _server = new TestServer(builder);
    
            Client = _server.CreateClient();
            Client.BaseAddress = new Uri("http://localhost:5000");
        }
    
        public HttpClient Client { get; }
    
        public void Dispose()
        {
            Client.Dispose();
            _server.Dispose();
        }
    }
