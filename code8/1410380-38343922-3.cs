    public static void SendMessage(string messageName, object message, object sender)
    {
        var actionKeys = RegisteredActions.Keys.ToList();
        foreach (Tuple<string, object> actionKey in actionKeys)
        {
            if (actionKey.Item1 == messageName)
            {
                Action<object, object> action;
                if (RegisteredActions.TryGetValue(actionKey, out action))
                {
                    action?.Invoke(message, sender);
                }
            }
        }
    }
