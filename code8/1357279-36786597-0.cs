        public static Delegate AddHandler(this object obj, string eventName, Action action)
    {
        // Filter list by event name
        EventInfo ev = obj.GetType().GetEvents().Where(x => x.Name == eventName).FirstOrDefault();
        if (ev == null)
        {
            Debug.LogWarning(eventName + " not found on " + obj.ToString());
            return null;
        }
        // Simple case - the signature matches so just add the new handler to the list
        if (ev.EventHandlerType == typeof(Action))
        {
            ev.AddEventHandler(obj, action);
            return action;
        }
        Delegate del = CreateDelegate(ev, action);
        ev.AddEventHandler(obj, del);
        return del;
    }
    public static void RemoveHandler(this object obj, string eventName, Action action)
    {
        // Filter list by event name
        var ev = obj.GetType().GetEvents().Where(x => x.Name == eventName).FirstOrDefault();
        if (ev == null)
        {
            Debug.LogWarning(eventName + " not found on " + obj.ToString());
            return;
        }
        // Simple case - the signature matches so just add the new handler to the list
        if (ev.EventHandlerType == typeof(Action))
        {
            ev.RemoveEventHandler(obj, action);
        }
        else
        {
            Delegate del = CreateDelegate(ev, action);
            ev.RemoveEventHandler(obj, del);
        }
    }
    private static Delegate CreateDelegate(EventInfo ev, Action action)
    {
        // Retrieve the parameter types of the event handler
        var parameters = ev.EventHandlerType.GetMethod("Invoke").GetParameters();
        ParameterExpression[] parameters2 = Array.ConvertAll(parameters, x => Expression.Parameter(x.ParameterType, x.Name));
        MethodCallExpression call;
        // We are "opening" the delegate and directly using the Target and the Method.
        if (action.Target == null) // Event is static
            call = Expression.Call(action.Method);
        else // Event is instanced
            call = Expression.Call(Expression.Constant(action.Target), action.Method);
        var exp = Expression.Lambda(ev.EventHandlerType, call, parameters2);
        return exp.Compile();
    }
