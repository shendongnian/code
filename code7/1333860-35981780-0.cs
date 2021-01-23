    public class SetTempDataModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            Controller controller = filterContext.Controller as Controller;
            if (controller != null)
            {
                controller.TempData["ModelState"] = controller.ViewData.ModelState;
            }
        }
    }
    public class RestoreModelStateFromTempDataAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            Controller controller = filterContext.Controller as Controller;
            if (controller != null & controller.TempData.ContainsKey("ModelState"))
            {
                controller.ViewData.ModelState.Merge(
                    (ModelStateDictionary)controller.TempData["ModelState"]);
            }
        }
    }
