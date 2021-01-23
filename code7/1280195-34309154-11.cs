    namespace WebApplication
    {
        public class NamespaceConstraint : ActionMethodSelectorAttribute
        {
            public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
            {
                var dataTokenNamespace = (string)routeContext.RouteData.DataTokens.FirstOrDefault(dt => dt.Key == "Namespace").Value;
                var actionNamespace = ((ControllerActionDescriptor)action).MethodInfo.DeclaringType.FullName;
    
                return dataTokenNamespace == actionNamespace;
            }
        }
    }
