    public class ProductMustExistConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            var productNameParam = values[parameterName];
            if (productNameParam != null)
            {
                var productName = productNameParam.ToString();
                /* Assuming you use Entity Framework and have a set of products 
                 * (you can replace with your own logic to fetch the products from 
                 *  the database). 
                 */
                return context.Products.Any(p => p.Name == productName);
            }
            return false;
            
        }
    }
