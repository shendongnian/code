    public class LoadMenu : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var vb = filterContext.Controller.ViewBag; 
            vb.Menu = "Some string you want";
        }
    }
