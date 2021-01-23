	public class InternationalizationAttribute : ActionFilterAttribute {
		public override void OnActionExecuting(ActionExecutingContext filterContext) {
			var cookie = filterContext.HttpContext.Request.Cookies["iln8Cookie"];
		
			string language = cookie != null ? cookie.Values["Language"] : "en";
			string culture = cookie != null ? cookie.Values["Culture"] : "AU";
			Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(string.Format("{0}-{1}", language, culture));
			Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(string.Format("{0}-{1}", language, culture));
		}
	}
