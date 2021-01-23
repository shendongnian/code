    public class SomeConstraint : IHttpRouteConstraint
    {
        public bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName, 
            IDictionary<string, object> values, HttpRouteDirection routeDirection)
        {
            //get value from values dictionary object
            //return true or false 
            //false will block the call
         }
    }
