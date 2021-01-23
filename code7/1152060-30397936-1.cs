    Dictionary<string, Func<string[], int>> functions = 
        new Dictionary<string, Func<string[], int>>
    {
        { "Foo", CountParameters },
        { "Bar", SomeOtherMethodName }
    };
    ...
    private static int CountParameters(string[] parameters)
    {
        return parameters.Length;
    }
    // etc
