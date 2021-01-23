    private static Dictionary<string, Action> mapping =
        new Dictionary<string, Action>
        {
            { "1", MethodOne },
            // ...
            { "150", Method150 }
        };
    public void Invoker(string selector)
    {
        Action method;
        if (mapping.TryGetValue(selector, out method)
        {
            method.Invoke();
            return;
        }
        // TODO: method not found
    }
