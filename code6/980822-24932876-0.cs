    public static IHttpRoute MapHttpRoute(this HttpRouteCollection routes, string name, string routeTemplate, object defaults, object constraints, HttpMessageHandler handler, object dataTokens)
    {
      HttpRouteValueDictionary defaultsDictionary = new HttpRouteValueDictionary(defaults);
      HttpRouteValueDictionary constraintsDictionary = new HttpRouteValueDictionary(constraints);
      HttpRouteValueDictionary dataTokensDictionary = new HttpRouteValueDictionary(dataTokens);
      IHttpRoute route = routes.CreateRoute(routeTemplate, defaultsDictionary, constraintsDictionary, dataTokens: dataTokensDictionary, handler: handler);
      routes.Add(name, route);
      return route;
    }
