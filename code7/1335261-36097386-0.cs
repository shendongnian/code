    public static string EvalueateChartModelTemplate<T>(T model, string cssResourceName, string tempKey)
    {
        string template = StreamEmbeddedResource(cssResourceName);
        string result = Engine.Razor.RunCompile(template, tempKey, typeof(T), model);
        return result;
    }
