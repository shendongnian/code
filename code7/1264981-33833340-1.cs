    public class IdConversionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.QueryString["myID"] != null)
            {
                filterContext.ActionParameters.Clear();
                filterContext.ActionParameters.Add("id", Convert.ToInt32(filterContext.HttpContext.Request.QueryString["myID"]));
            }
        }
    } 
