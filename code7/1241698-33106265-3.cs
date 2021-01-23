    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
         public override void OnAuthorization(HttpActionContext actionContext)
         {
               string controllerName = actionContext.ControllerContext.ControllerDescriptor.ControllerName;
               bool shouldAuthorize = //.. Check if controller needs authorization
               if(!shouldAuthorize)
                   SkipAuthorization(actionContext);
               else if(!IsAuthorized(actionContext))
                   HandleUnauthorizedRequest(actionContext);
         }
    }
