    public class IntranetAction : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            bool isIPAddressValid = false;////TODO: Check the IP validity here
            if (ssIPAddressValid)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Account",
                    action = "Login"
                }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
