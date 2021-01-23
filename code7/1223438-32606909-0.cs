        public class AsyncFixHandler : DelegatingHandler
        {
            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                try
                {
                    return await base.SendAsync(request, cancellationToken);
                }
                catch (TaskCanceledException)
                {
                    // TODO: Log the issue here
                    return new HttpResponseMessage(HttpStatusCode.InternalServerError);
                }
            }
        }
