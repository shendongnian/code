    public class ResourceFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var attributes = this.GetAllAttributes(filterContext.ActionDescriptor);
            foreach (ResourceAttribute attribute in attributes)
            {
                var name = attribute.Name;
                var value = attribute.Value;
                // Do something with the meta-data from the attribute...
            }
            // Set the ViewData
            filterContext.Controller.ViewData["SomeKey"] = "SomeValue";
        }
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // Do nothing
        }
        public IEnumerable<ResourceAttribute> GetAllAttributes(ActionDescriptor actionDescriptor)
        {
            var result = new List<ResourceAttribute>();
            // Check if the attribute exists on the action method
            result.AddRange(
                actionDescriptor
                    .GetCustomAttributes(typeof(ResourceAttribute), false) as ResourceAttribute[]
            );
            // Check if the attribute exists on the controller
            result.AddRange(
                actionDescriptor
                    .ControllerDescriptor
                    .GetCustomAttributes(typeof(ResourceAttribute), false) as ResourceAttribute[]
            );
            return result;
        }
    }
