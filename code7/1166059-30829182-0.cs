        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var filters = new List<FilterAttribute>();
            filters.AddRange(filterContext.ActionDescriptor.GetFilterAttributes(false));
            filters.AddRange(filterContext.ActionDescriptor.ControllerDescriptor.GetFilterAttributes(false));
            var roles = filters.OfType<AuthorizeAttribute>().Select(f => f.Roles);
            ...
        }
