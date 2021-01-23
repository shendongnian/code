    public class SomeFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var model = filterContext.Controller.ViewData.Model as YourModelType;
            
            //Modify model here or assign a new object to it.
            //Then pass the modified model to view
            filterContext.Controller.ViewData.Model= model;
            base.OnActionExecuted(filterContext);
        }
    }
