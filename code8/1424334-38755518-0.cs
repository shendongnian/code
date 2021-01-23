    public class MessageHandler1 : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //Update the request url by replacing the base address to the internal endpoint.
            return base.SendAsync(request, cancellationToken);
            
        }
    }
