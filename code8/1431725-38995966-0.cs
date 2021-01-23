    public class MyNoActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {            
            if (IfDisabledLogic(actionContext))
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            else                
              base.OnActionExecuting(actionContext);
        }
    }
    [MyNoActionFilter]
    public class ValuesController : ApiController
    {
        // web api controller logic...
    }
