    public class LocalizationActionFilterAttribute : ActionFilterAttribute
    {
        private const string LanguageCookieName = "MyLanguageCookieName";
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var cookie = filterContext.HttpContext.Request.Cookies[LanguageCookieName];
            string lang;
            if (cookie != null)
            {
                lang = cookie.Value;
            }
            else
            {
                lang = ConfigurationManager.AppSettings["DefaultCulture"] ?? "fa-IR";
                var httpCookie = new HttpCookie(LanguageCookieName, lang) { Expires = DateTime.Now.AddYears(1) };
                filterContext.HttpContext.Response.SetCookie(httpCookie);
            }
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(lang);
            base.OnActionExecuting(filterContext);
        }
    }
