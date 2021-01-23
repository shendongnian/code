    using System.Globalization;
    using System.Threading;
    using System.Web.Mvc;
    public class LocalizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var values = filterContext.RouteData.Values;
            string language = (string)values["language"] ?? "en";
            string culture = (string)values["culture"] ?? "US";
            CultureInfo culture = CultureInfo.GetCultureInfo(string.Format("{0}-{1}", language, culture));
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }
    }
