     public class MyAuthorizeAttribute : AuthorizeAttribute
     {
         string role;
         string application
         public MyAuthorizeAttribute (string role, string application){ 
            this. role = roles;
            this.application = application;
         }
         protected override bool IsAuthorized(HttpActionContext actionContext)  {
               var routeData = actionContext.ControllerContext.RouteData;
               //do your checks
         }
     }
