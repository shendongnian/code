    delegate string GetParametersDelegate(Delegate method, params object[] parameters);
    static GetParametersDelegate GetParametersFunc = (method, parameters) =>
    {
        var paramNames = method.Method.GetParameters().Select(pInfo => pInfo.Name);
        return
            paramNames.Select((name, index) => $"{name}={parameters[index]?.ToString() ?? "null"}")
                .Aggregate((a, b) => $"{a},{b}");
    };
