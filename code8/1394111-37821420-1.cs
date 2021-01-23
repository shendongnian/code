    using Microsoft.AspNetCore.Http;
    using System.Globalization;
    using System.Threading.Tasks;
    
    namespace MyNamespace
    {
        public class MyRequestLocalizationMiddleware
        {
            private readonly RequestDelegate _next;
    
            public MyRequestLocalizationMiddleware(RequestDelegate next)
            {
                _next = next;
            }
    
            public async Task Invoke(HttpContext context)
            {
                var defaultCulture = new CultureInfo("pt-BR");
                SetCurrentCulture(defaultCulture, defaultCulture);
                await _next(context);
            }
    
            private void SetCurrentCulture(CultureInfo culture, CultureInfo uiCulture)
            {
                CultureInfo.CurrentCulture = new CultureInfo(culture.Name);
            }
        }
    }
