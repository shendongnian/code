    public class AuthorizationHeaderHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage pRequest, CancellationToken pCancellationToken)
        {
            IEnumerable<string> apiKeyHeaderValues = null; 
            if (!pRequest.Headers.TryGetValues("Authorization", out apiKeyHeaderValues)
                || !TokenRepo.IsVallidToken(apiKeyHeaderValues))
            {
                var response = new HttpResponseMessage(HttpStatusCode.Unauthorized)
                {
                    Content = new StringContent("{\"error\": \"invalid_token\"}")
                };
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return Task.Factory.StartNew(() => response);
            }
            return base.SendAsync(pRequest, pCancellationToken);
        }
    }
       
