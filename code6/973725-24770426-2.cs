    public class IsRpcConstraint : IHttpRouteConstraint
    {
        public bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName, IDictionary<string, object> values,
                          HttpRouteDirection routeDirection)
        {
            if (values.ContainsKey(parameterName))
            {
                string action = values[parameterName] as string;
                return !string.IsNullOrEmpty(action) && IsRpcAction(action);
            }
            else
            {
                return false;    
            }
        }
        private bool IsRpcAction(string actionName)
        {
            bool isRpc = true;
            Guid guidId;
            int intId;
            if (Guid.TryParse(actionName, out guidId))
            {
                isRpc = false;
            }
            else if (int.TryParse(actionName, out intId))
            {
                isRpc = false;
            }
            return isRpc;
        }
    }
