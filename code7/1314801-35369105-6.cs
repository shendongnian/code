    public class CheckEnvironmentFilterAttribute : ActionFilterAttribute
    {
         public override void OnActionExecuting(HttpActionContext actionContext)
         {
              // Use the "as" cast to don't throw an invalid cast exception
              // if this attribute is applied to the wrong controller...
              IDebuggable debuggableController =
                       actionContext.ControllerContext.Controller as IDebuggable;
    
              if(debuggableController != null)
              {
                    debuggableController.IsDebugging = true;
              }
         }
    }
