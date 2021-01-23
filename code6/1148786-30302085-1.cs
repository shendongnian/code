    public static void AddHandler(this object obj, Action action)
    {
        var events = obj.GetEvents();
        foreach (var @event in events)
        {
            // Simple case
            if (@event.EventHandlerType == typeof(Action))
            {
                @event.AddEventHandler(obj, action);
            }
            else
            {
                // From here: http://stackoverflow.com/a/429564/613130
                // We retrieve the parameter types of the event handler
                var parameters = @event.EventHandlerType.GetMethod("Invoke").GetParameters();
                // We convert it to ParameterExpression[]
                ParameterExpression[] parameters2 = Array.ConvertAll(parameters, x => Expression.Parameter(x.ParameterType));
                    
                MethodCallExpression call;
                // Note that we are "opening" the delegate and using
                // directly the Target and the Method! Inside the 
                // LambdaExpression we will build there won't be a 
                // delegate call, there will be a method call!
                if (action.Target == null)
                {
                    // static case
                    call = Expression.Call(action.Method);
                }
                else
                {
                    // instance type
                    call = Expression.Call(Expression.Constant(action.Target), action.Method);
                }
                // If you are OK to create a delegate that calls another
                // delegate, you can:
                // call = Expression.Call(Expression.Constant(action), typeof(Action).GetMethod("Invoke"));
                // instead of the big if/else
                var lambda = Expression.Lambda(@event.EventHandlerType, call, parameters2);
                @event.AddEventHandler(obj, lambda.Compile());
            }
        }
    }
