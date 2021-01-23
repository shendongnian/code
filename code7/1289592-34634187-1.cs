    public class GlobalActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controllerNamespace = context.Controller.GetType().Namespace;
            var pipeRoute = context.RouteData.Routers.OfType<TemplateRoute>().FirstOrDefault(x => x.Name == "CustomPipeRoute");
            if (pipeRoute != null) // We are using /pipe1
            {
                // Check your conditions here...
                // ...
                // You can redirect to somewhere else if you want.
                var controller = (Controller)context.Controller;
                context.Result = controller.RedirectToAction("Index", "Controller");
            }
        }
    
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
