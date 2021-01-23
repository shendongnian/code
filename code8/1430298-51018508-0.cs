    class MyExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {            
            HttpControllerContext controllerContext = context.ExceptionContext.ControllerContext;            
            if (controllerContext != null)
            {
                System.Web.Http.ApiController apiController = controllerContext.Controller as ApiController;
                if (apiController != null)
                {
                    HttpActionContext actionContext = apiController.ActionContext;
                    // ...
                }
             }
             
             // ...
             
             base.Handle(context);
        }
        
        public override Boolean ShouldHandle(ExceptionHandlerContext context)
        {
            return true;
        }            
    }
