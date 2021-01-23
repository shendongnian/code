    public class RouteCultureProvider : IRequestCultureProvider
    {
        private CultureInfo defaultCulture;
        private CultureInfo defaultUICulture;
        public RouteCultureProvider(RequestCulture requestCulture)
        {
            this.defaultCulture = requestCulture.Culture;
            this.defaultUICulture = requestCulture.UICulture;
        }
        public Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            //Parsing language from url path, which looks like "/en/home/index"
            PathString url = httpContext.Request.Path;
            // Test any culture in route
            if (url.ToString().Length <= 1)
            {
                // Set default Culture and default UICulture
                return Task.FromResult<ProviderCultureResult>(new ProviderCultureResult(this.defaultCulture.TwoLetterISOLanguageName, this.defaultUICulture.TwoLetterISOLanguageName));
            }
            var parts = httpContext.Request.Path.Value.Split('/');
            var culture = parts[1];
            // Test if the culture is properly formatted
            if (!Regex.IsMatch(culture, @"^[a-z]{2}(-[A-Z]{2})*$"))
            {
                // Set default Culture and default UICulture
                return Task.FromResult<ProviderCultureResult>(new ProviderCultureResult(this.defaultCulture.TwoLetterISOLanguageName, this.defaultUICulture.TwoLetterISOLanguageName));
            }
            // Set Culture and UICulture from route culture parameter
            return Task.FromResult<ProviderCultureResult>(new ProviderCultureResult(culture, culture));
        }
    }
