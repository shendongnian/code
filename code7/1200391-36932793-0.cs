        public class PermissionAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext context)
            {
                foreach (var filterDescriptors in context.ActionDescriptor.FilterDescriptors)
                {
                    if (filterDescriptors.Filter.GetType() == typeof(AllowAnonymousFilter))
                    {
                        return;
                    }
                }
            }
        }
