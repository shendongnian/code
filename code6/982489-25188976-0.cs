    public class CustomAuthorizationFilter : IAuthorizationFilter
    {
        public bool AllowMultiple { get { return false; } }
    
        public Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(
            HttpActionContext actionContext,
            CancellationToken cancellationToken,
            Func<Task<HttpResponseMessage>> continuation)
        {
            // check the auth
            var request = actionContext.Request;
            var odataPath = request.ODataProperties().Path;
            if (odataPath != null && odataPath.NavigationSource != null &&
                odataPath.NavigationSource.Name == "Products")
            {
                // only allow admin access
                IEnumerable<string> users;
                request.Headers.TryGetValues("user", out users);
                if (users == null || users.FirstOrDefault() != "admin")
                {
                    throw new HttpResponseException(HttpStatusCode.Unauthorized);
                }
            }
    
            return continuation();
        }
    }
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Filters.Add(new CustomAuthorizationFilter());
