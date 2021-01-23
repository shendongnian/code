     public class BaseController : Controller
    {
        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            //Localization in Base controller:
            string language = (string)RouteData.Values["language"] ?? "de";
            string culture = (string)RouteData.Values["culture"] ?? "DE";
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(string.Format("{0}-{1}", language, culture));
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(string.Format("{0}-{1}", language, culture));
            return base.BeginExecuteCore(callback, state);
        }
    }
