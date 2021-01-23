    public class CheckEnvironmentFilterAttribute : ActionFilterAttribute
    {
         public override void OnActionExecuting(HttpActionContext actionContext)
         {
              // Use the "as" cast to don't throw an invalid cast exception
              // if this attribute is applied to the wrong controller...
              ServiceController serviceController =
                       actionContext.ControllerContext.Controller as ServiceController;
    
              if(serviceController != null)
              {
                    serviceController.IsDebugging = true;
              }
         }
    }
