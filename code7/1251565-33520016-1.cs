    namespace NorthWindMVC.Filters
    {
        public class TestActionFilter : ActionFilterAttribute
        {
            public override void OnActionExecuted(ActionExecutedContext filterContext)
            {
                filterContext.Controller.ViewData["TestProperty"] = "mahmut";
            }
        }
    }
