     public class MyConstraint : IHttpRouteConstraint
     {
           public bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName, IDictionary<string, object> values, HttpRouteDirection routeDirection)
           {
                string parameters = string.Join(Environment.NewLine, values.Select(p => p.Value.GetType().FullName).ToArray());
                return true;
           }
      } 
