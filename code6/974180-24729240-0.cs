    public class RequestMessageHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            RequestMessage.Contents = request;
            return base.SendAsync(request, cancellationToken);
        }
    }
