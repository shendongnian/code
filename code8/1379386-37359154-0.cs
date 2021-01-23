    public abstract partial class BaseController : Controller
        {
               protected override void OnActionExecuting(ActionExecutingContext ctx)
                {            
                    base.OnActionExecuting(ctx);
                    ViewData["user"] = "user";            
                }
        }
