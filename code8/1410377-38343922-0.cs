    public static void Register(string actionName, object registerer, Action<object, object> action)
    {
        var actionKey = new Tuple<string, object>(actionName, registerer);
        if (!RegisteredActions.ContainsKey(actionKey))
        {
            RegisteredActions.Add(actionKey, action);
        }
        else
        {
            RegisteredActions[actionKey] = action;
        }
    }
