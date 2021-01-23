    public class BaseController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
           //Do your logging
           // and redirect / return error view
        }
    }
