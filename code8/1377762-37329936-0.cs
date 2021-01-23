    public class TestFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewBag.foo = "1";
            base.OnActionExecuting(context);
        }
    }
    
    [ServiceFilter(typeof(TestFilter))]
    public class TestController : Controller
    {
    }
