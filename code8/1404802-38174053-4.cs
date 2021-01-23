    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.AspNetCore.Routing;
    using System;
    using System.Globalization;
    namespace astika.Models
    {
    public class CultureToUrlActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context) { }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            bool redirect = false;
            string culture = context.RouteData.Values["culture"].ToString().ToLower();
            redirect = String.IsNullOrEmpty(culture);
            if (!redirect)
            {
                try
                {
                    CultureInfo ci = new CultureInfo(culture);
                    redirect = Startup.supportedCultures.FindIndex(x => x.TwoLetterISOLanguageName.ToLower() == culture) < 0;
                }
                catch
                {
                    redirect = true;
                }
            }
       
            if (redirect)
            {
                CultureInfo cid = new CultureInfo(Startup.defaultCulture);
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { culture = cid.TwoLetterISOLanguageName, controller = "Home", action = "Index" }));
            }
        }
    }
    }
