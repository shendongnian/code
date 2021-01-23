    public class SomeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var yourstring = filterContext.RequestContext.HttpContext.Request.QueryString["string"];
            if (!string.IsNullOrWhiteSpace(yourstring))
            {
                if (yourstring is not ok) 
                filterContext.Result =
                    new RedirectToRouteResult(
                        new RouteValueDictionary
                        {
                            {"controller", "SomeCtrl"},
                            {"action", "SomeAction"}
                        });
            }
            base.OnActionExecuting(filterContext);
            
        }
