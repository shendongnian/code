    public class MyActionInvoker: ControllerActionInvoker
    {
        protected override ActionResult CreateActionResult(ControllerContext controllerContext, ActionDescriptor actionDescriptor, object actionReturnValue)
        {
            // Your behaviour
        }
    }
    public class MyController: Controller
    {
        protected override void Initialize(RequestContext requestContext)
        {
            ActionInvoker = new MyActionInvoker();
        }
        protected override IActionInvoker CreateActionInvoker()
        {
            return new MyActionInvoker();
        }
    }
