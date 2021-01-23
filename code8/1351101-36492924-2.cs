    public class MediaTypeDelegatingHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var url = request.RequestUri.ToString();
            //TODO: Maybe a more elegant check?
            if (url.EndsWith(".json"))
            {
                // clear the accept and replace it to use JSON.
                request.Headers.Accept.Clear();
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
            else if (url.EndsWith(".xml"))
            {
                request.Headers.Accept.Clear();
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
            }
            return await base.SendAsync(request, cancellationToken);
        }
    }
