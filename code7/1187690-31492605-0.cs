    public class RestrictionCheckAttribute : ActionFilterAttribute 
    {
        public override void OnActionExecuting(HttpActionContext actionContext) 
        {
            if (IsActionRestricted(actionContext))
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
            }
            base.OnActionExecuting(actionContext);
        }
    }
