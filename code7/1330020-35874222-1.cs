    public class GetCountFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
            var counter = (actionExecutedContext.ActionContext.Response.Content as ObjectContent)?.Value as IHasCount;
            if (counter != null)
                actionExecutedContext.ActionContext.Response.Headers.Add("X-Total-Count", counter.TotalCount.ToString());
        }
    }
	
