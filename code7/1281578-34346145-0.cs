    var methodCallExpression = expression.Body as MethodCallExpression;
    if (methodCallExpression == null)
    {                
        throw new ArgumentException("Not a MethodCallExpression", "expression");
    }
            
    var methodParameters = methodCallExpression.Method.GetParameters();
    var methodArguments = methodCallExpression.Arguments.ToList();
    var rawRouteValueDictionary = methodParameters.Select(m => m.Name)
                                                  .Zip(methodArguments, (parameter, argument) => new { parameter, argument })
                                                  .ToDictionary(kvp => kvp.parameter, kvp => kvp.argument);
    var routeValueDictionary = new RouteValueDictionary(rawRouteValueDictionary);
    // action and controller obtained through your logic 
    // (note routing can be in effect, so controller and method name don't have to be the name that the URL helper expects)
    return url.Action(action, controller, routeValueDictionary);
