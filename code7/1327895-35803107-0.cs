    public class PlumberUrlConstraint: IRouteConstraint
    {
       public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
       {
          var db = new YourDbContext();
          if (values[parameterName] != null)
          {
            var UsuApelido = values[parameterName].ToString();
            return db.Plumbers.Any(p => p.Name == UsuApelido);
          }
          return false;
       }
    }
