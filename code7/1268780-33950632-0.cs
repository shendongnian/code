    public class SomeFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var model = filterContext.Controller.ViewData.Model as YourModelType;
            
            //Modify model here and assign it to modifiedModel
            //Then pass the modifiedModel to view
            filterContext.Controller.ViewData.Model= modifiedModel;
            base.OnActionExecuted(filterContext);
        }
    }
