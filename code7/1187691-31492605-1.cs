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
        private bool IsActionRestricted(HttpActionContext actionContext)
        {
            // Add your restriction check logic here.
        }
    }
