      public class CheckShownInterstitial : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            if (!filterContext.IsChildAction &&
                !filterContext.HttpContext.Request.IsAjaxRequest() &&
                filterContext.Result is ViewResult)
            {
                var ViewBag = filterContext.Controller.ViewBag;
                var Request = filterContext.HttpContext.Request;
    
                ViewBag.shownInterstitial = false;
                if (Request.Cookies["Interstitial"] != null)
                {
                    ViewBag.shownInterstitial = true;
                }
                //Interstitial cookie does NOT exist.
                else
                {
                    ViewBag.shownInterstitial = false;
                }
            }
        }
    }
