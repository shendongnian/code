    public class AuroraClient : IAuroraClient
    {
        private readonly HttpClient _client;
        public AuroraClient() : this(new HttpClientHandler())
        {
        }
        public AuroraClient(HttpMessageHandler messageHandler)
        {
            _client = new HttpClient(messageHandler);
        }
    }
