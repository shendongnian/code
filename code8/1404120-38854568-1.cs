    public class ControllerActionInvokerWithDefaultJsonResult : ControllerActionInvoker
    {
        public const string JsonContentType = "application/json";
    
        protected override ActionResult CreateActionResult(ControllerContext controllerContext, ActionDescriptor actionDescriptor, object actionReturnValue)
        {
            if (controllerContext.HttpContext.Request.Path.StartsWith("/api/"))
            {
                return (actionReturnValue as ActionResult) 
                    ?? new JsonResult
                    {
                        Data = actionReturnValue,
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
            }
            return base.CreateActionResult(controllerContext, actionDescriptor, actionReturnValue);
        }
    }
