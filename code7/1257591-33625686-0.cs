    public class BaseController : Controller
    {
        private const string LanguageCookieName = "MyLanguageCookieName";
        protected override void ExecuteCore()
        {
            var cookie = HttpContext.Request.Cookies[LanguageCookieName];
            string lang;
            if (cookie != null)
            {
                lang = cookie.Value;
            }
            else
            {
                lang = ConfigurationManager.AppSettings["DefaultCulture"] ?? "fa-IR";
                var httpCookie = new HttpCookie(LanguageCookieName, lang) { Expires = DateTime.Now.AddYears(1) };
                HttpContext.Response.SetCookie(httpCookie);
            }
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(lang);
            base.ExecuteCore();
        }
    }
