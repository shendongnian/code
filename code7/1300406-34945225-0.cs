    public class ContactNumberActionFilter : IActionFilter
    {
        private readonly string defaultContactNumber;
        public ContactNumberActionFilter(string defaultContactNumber)
        {
            this.defaultContactNumber = defaultContactNumber;
        }
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // No implementation
        }
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.Controller;
            var provider = controller as IContactNumber;
            var contactNumber = (provider == null) ? this.defaultContactNumber : provider.ContactNumber;
            controller.ViewData.Add("ContactNumber", contactNumber);
        }
    }
