    var methodCallExpression = expression.Body as MethodCallExpression;
    if (methodCallExpression == null)
    {                
        throw new ArgumentException("Not a MethodCallExpression", "expression");
    }
            
    var methodParameters = methodCallExpression.Method.GetParameters();
    var methodArguments = methodCallExpression.Arguments.ToList();
    var routeValueArguments = methodArguments.Select(EvaluateExpression);
    var rawRouteValueDictionary = methodParameters.Select(m => m.Name)
                                .Zip(routeValueArguments, (parameter, argument) => new
                                {
                                    parameter,
                                    argument
                                })
                                .ToDictionary(kvp => kvp.parameter, kvp => kvp.argument);
    var routeValueDictionary = new RouteValueDictionary(rawRouteValueDictionary);
    // action and controller obtained through your logic 
    return url.Action(action, controller, routeValueDictionary);
