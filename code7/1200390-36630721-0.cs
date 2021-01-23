        public static IEnumerable<T> GetCustomAttributes<T>(this Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor actionDescriptor) where T : Attribute
        {
            var controllerActionDescriptor = actionDescriptor as ControllerActionDescriptor;
            if (controllerActionDescriptor != null)
            {
                return controllerActionDescriptor.MethodInfo.GetCustomAttributes<T>();
            }
            return Enumerable.Empty<T>();
        }
