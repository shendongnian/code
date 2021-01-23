    public class ProductUrlConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            List<string> customPages = new List<string> {"Ferrari", "Porche"};
            if (values[parameterName] != null)
            {
                var slug= values[parameterName].ToString();
                var product = customPages.Where(p => p == slug).FirstOrDefault();
                if(!string.isNullorEmpty(product))
                {
                     HttpContext.Items["customProduct"] = product;
                     return true;
                }
            }
            return false;
        }
    }
