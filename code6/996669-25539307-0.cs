    public class LoggingMessageHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            
            var response = await base.SendAsync(request, cancellationToken);
            if (request.Method == HttpMethod.Post)
            {
                // Log whatever you want here
                Console.WriteLine(request.ToString());
                Console.WriteLine(response.ToString());
            }
            return response;
        }
    }
