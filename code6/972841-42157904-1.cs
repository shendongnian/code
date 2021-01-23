    public class HttpsFilter : IAuthorizationFilter
    {
        public bool AllowMultiple => false;
        public Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            List<HttpsRequiredAttribute> action = actionContext.ActionDescriptor.GetCustomAttributes<HttpsRequiredAttribute>().ToList();
            List<HttpsRequiredAttribute> controller = actionContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes<HttpsRequiredAttribute>().ToList();
            // if neither the controller or action have the HttpsRequiredAttribute then don't bother checking if connection is HTTPS
            if (!action.Any() && !controller.Any())
                return continuation();
            // if HTTPS is required but the connection is not HTTPS return a 403 forbidden
            if (!string.Equals(actionContext.Request.RequestUri.Scheme, "https", StringComparison.OrdinalIgnoreCase))
            {
                return Task.Factory.StartNew(() => new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden)
                {
                    ReasonPhrase = "Https Required",
                    Content = new StringContent("Https Required")
                });
            }
            return continuation();            
        }
    }
