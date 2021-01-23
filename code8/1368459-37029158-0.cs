    public class CustomAuthFilter : AuthorizeAttribute
    {
        private BaseController controller;
        public override void OnAuthorization(HttpActionContext actionContext)
        {   
            controller = actionContext.ControllerContext.Controller as BaseController;
            //Some code ommitted for clarity
            if (controller != null)
                controller.CurrentUserId = userAccount[0];
        }
    }
