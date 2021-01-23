    public class LogResponseHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);
            var responseString = await response.Content.ReadAsStringAsync();
            //log response string to file
            return response;
        }
    }
