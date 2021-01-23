    delegate string GetParametersDelegate(Delegate method, params object[] parameters);
    static GetParametersDelegate GetParametersFunc = (method, parameters) =>
    {
        var paramNames = method.Method.GetParameters().Select(_ => _.Name);
        return
            paramNames.Select((_, i) => $"{_}={parameters[i]?.ToString() ?? "null"}")
                .Aggregate((a, b) => $"{a},{b}");
    };
