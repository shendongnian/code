    public class LangSettingActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var routeData= actionContext.Request.GetRouteData();
            object langCode;
            if (routeData.Values.TryGetValue("lang", out langCode))
            {
              //the languageCode from url is in langCode variable. Use it as needed.
              //Thread.CurrentThread.CurrentUICulture =
                                        //CultureInfo.GetCultureInfo(langCode.ToString());
            }
            base.OnActionExecuting(actionContext);
        }
    }
