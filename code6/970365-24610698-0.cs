    public class JsonHeaderHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage message, CancellationToken token)
        {
            var response = await base.SendAsync(message, token);
            IEnumerable<string> contentTypes;
            if(response.Headers.TryGetValues("Content-Type", out contentTypes)) 
            {
                // Check if there is an application/json Content-Type header
                // There should be 0 or 1, a call to FirstOrDefault() would be fine
                if(contentTypes.Any(ct => ct.Contains("application/json")))
                {
                    response.Headers.Add("X-Answer", "42");
                    response.Headers.Add("X-Question", "Unknown");
                }
            }
            return response;
        }
    }
    // And using HttpConfiguration configuration
    configuration.MessageHandlers.Add(new JsonHeaderHandler());
