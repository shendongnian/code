    public class CustomAuthorize : AuthorizeAttribute
    {
         public override void OnAuthorization(HttpActionContext actionContext)
         {
               string controllerName = actionContext.ControllerContext.ControllerDescriptor.ControllerName;
               bool shouldAuthorize = //.. Check if correct controller
               if(!shouldAuthorize)
                   SkipAuthorization(actionContext);
               else if(!IsAuthorized(actionContext))
                   HandleUnauthorizedRequest(actionContext);
         }
    }
