    public class IsRestConstraint : IHttpRouteConstraint
    {
        public bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName, IDictionary<string, object> values,
                          HttpRouteDirection routeDirection)
        {
            if (values.ContainsKey(parameterName))
            {
                string id = values[parameterName] as string;
                return string.IsNullOrEmpty(id) || IsRest(id);
            }
            else
            {
                return false;
            }
        }
        private bool IsRest(string actionName)
        {
            bool isRest = false;
            Guid guidId;
            int intId;
            if (Guid.TryParse(actionName, out guidId))
            {
                isRest = true;
            }
            else if (int.TryParse(actionName, out intId))
            {
                isRest = true;
            }
            return isRest;
        }
    }
