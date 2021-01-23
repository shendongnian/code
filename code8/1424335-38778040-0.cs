    public class CustomHandler : DelegatingHandler
    {
        private static readonly FabricClient FabricClient = new FabricClient();
        private static readonly HttpCommunicationClientFactory CommunicationFactory = new HttpCommunicationClientFactory(new ServicePartitionResolver(() => FabricClient));
    
        public CustomHandler() : base(new HttpClientHandler()) {}
    
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var partitionClient = new ServicePartitionClient<HttpCommunicationClient>(CommunicationFactory, new Uri("fabric:/IdentityService/AuthApi"));
    
            return await partitionClient.InvokeWithRetryAsync(
                async (client) =>
                {
                    //replace base address with resolved url of internal endpoint
                    request.RequestUri = new Uri(client.Url, request.RequestUri.PathAndQuery);
                    return await base.SendAsync(request, cancellationToken);
                }, cancellationToken);
        }
    }
