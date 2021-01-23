    public class VersionObsessedHandler : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            if (request.Headers.UserAgent.Any())
            {
                var product = request.Headers.UserAgent.FirstOrDefault(s => s.Product.Name == "APPLICATION").Product;
                if (product != null && request.Headers.UserAgent.Any(s => !string.IsNullOrEmpty(s.Comment) && s.Comment.ToLower().Contains("ios")) && !product.Version.Equals(Constants.IOS_APP_VERSION))
                    return request.CreateResponse(HttpStatusCode.BadRequest, new { message = "Please update your application" });
            }
            return await base.SendAsync(request, cancellationToken); ;
        }
    }
