    public class MediaTypeDelegatingHandler: DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Headers.Accept.Contains(MediaTypeWithQualityHeaderValue.Parse("application/json")) == false)
            {
                return request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
            }
            return await base.SendAsync(request, cancellationToken);
        }
    }
