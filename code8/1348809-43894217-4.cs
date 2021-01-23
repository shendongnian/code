    public interface IMockHttpMessageHandler
    {
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken);
    }
    public class MockHttpMessageHandler : HttpMessageHandler
    {
        private readonly IMockHttpMessageHandler _realMockHandler;
        public MockHttpMessageHandler(IMockHttpMessageHandler realMockHandler)
        {
            _realMockHandler = realMockHandler;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return await _realMockHandler.SendAsync(request, cancellationToken);
        }
    }
