    public class CustomActionInvoker : ApiControllerActionSelector
    {
        public override HttpActionDescriptor SelectAction(HttpControllerContext controllerContext)
        {
            if (controllerContext == null)
                throw new ArgumentNullException("controllerContext");
            var routeData = (string)controllerContext.RouteData.Values["optional"];
            if (!string.IsNullOrWhiteSpace(routeData))
            {
                var actionInfo = controllerContext.ControllerDescriptor.ControllerType
                    .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly).ToList();
                var methodInfo = actionInfo.Where(a => a.Name.Contains(routeData)).FirstOrDefault();
                if (methodInfo != null)
                {
                    return new ReflectedHttpActionDescriptor(controllerContext.ControllerDescriptor, methodInfo);
                }
            }
            return base.SelectAction(controllerContext);
        }
    }
