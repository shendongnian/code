        public abstract class MessageHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var corrId = Guid.NewGuid();
            var requestMethod = request.Method.Method.ToString();
            var requestUri = request.RequestUri.ToString();
            var ipAddress = request.GetOwinContext().Request.RemoteIpAddress;
            var requestMessage = await request.Content.ReadAsByteArrayAsync();
            await LogMessageAsync(corrId, requestUri, ipAddress, "Request", requestMethod, request.Headers.ToString(), requestMessage, string.Empty);
            var response = await base.SendAsync(request, cancellationToken);
            var responseMessage = await response.Content.ReadAsByteArrayAsync();
            await LogMessageAsync(corrId, requestUri, ipAddress, "Response", requestMethod, response.Headers.ToString(), responseMessage, ((int)response.StatusCode).ToString() + "-" + response.ReasonPhrase);
            return response;
        }
        protected abstract Task LogMessageAsync(Guid CorrelationId, string APIUrl, string ClientIPAddress, string RequestResponse, string HttpMethod, string HttpHeaders, byte[] HttpMessage, string HttpStatusCode);
    }
    public class MessageLoggingHandler : MessageHandler
    {
        protected override async Task LogMessageAsync(Guid CorrelationId, string APIUrl, string ClientIPAddress, string RequestResponse, string HttpMethod, string HttpHeaders, byte[] HttpMessage, string HttpStatusCode)
        {
            // Create logger here
            //Do your logging here
        }
    }
