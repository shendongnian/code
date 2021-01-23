    public class RouteCultureProvider : IRequestCultureProvider
    {
        public Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            PathString url = httpContext.Request.Path;
            if (url.ToString().Length <= 1)
            {
                return Task.FromResult<ProviderCultureResult>(null);
            }
            var parts = httpContext.Request.Path.Value.Split('/');
            var culture = parts[1];
            // Test if the culture is properly formatted
            if (!Regex.IsMatch(culture, @"^[a-z]{2}(-[A-Z]{2})*$"))
            {
                return Task.FromResult<ProviderCultureResult>(null);
            }
            
            return Task.FromResult(new ProviderCultureResult(culture));
        }
    }
