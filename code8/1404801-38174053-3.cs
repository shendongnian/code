    using Microsoft.AspNetCore.Localization;
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using System.Globalization;
    namespace astika.Models
    {
    public class UrlCultureProvider: IRequestCultureProvider {
        public Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            if (httpContext == null) throw new ArgumentNullException(nameof(httpContext));
            var pathSegments = httpContext.Request.Path.Value.Trim('/').Split('/');
            
            string url_culture = pathSegments[0].ToLower();
            CultureInfo ci = Startup.supportedCultures.Find(x => x.TwoLetterISOLanguageName.ToLower() == url_culture);
            if (ci == null) ci = new CultureInfo(Startup.defaultCulture);
            CultureInfo.CurrentCulture = CultureInfo.CurrentUICulture = ci; 
            var result = new ProviderCultureResult(ci.Name, ci.Name);
            return Task.FromResult(result);
        }
    }
    }
