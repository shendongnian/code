    public class CheckEnvironmentFilterAttribute : ActionFilterAttribute
    {
         public override void OnActionExecuting(HttpActionContext actionContext)
         {
              ServiceController serviceController =
                       actionContext.ControllerContext.Controller as ServiceController;
    
              if(serviceController != null)
              {
                    serviceController.IsDebugging = true;
              }
         }
    }
