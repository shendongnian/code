    public class VerifySetupIsGood : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var dbSetDate = context.HttpContext.Application["DbSetDate"] as string;
            if (String.IsNullOrEmpty(dbSetDate))
            {
                var values = new Dictionary<string, string> { { "action", "LoadScreen" },
                                                                 { "controller", "Loading" } };
                var r = new RouteValueDictionary(values);
                //redirect the request to MissingDatabase action method.
                context.Result = new RedirectToRouteResult(r);
            }            
            base.OnActionExecuting(context);
        }
    }
