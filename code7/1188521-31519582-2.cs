    public class BaseController: Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            // Bail if we can't do anything; app will crash.
            if (filterContext == null)
                return;
                // since we're handling this, log to elmah
        
            var ex = filterContext.Exception ?? new Exception("No further information exists.");
            LogException(ex);
        
            filterContext.ExceptionHandled = true;
            var data = new ErrorPresentation
                {
                    ErrorMessage = HttpUtility.HtmlEncode(ex.Message),
                    TheException = ex,
                    ShowMessage = !(filterContext.Exception == null),
                    ShowLink = false
                };
            filterContext.Result = View("Index", data); // to redirect to the index page
        }
    }
