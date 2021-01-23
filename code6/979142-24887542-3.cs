    public void IAlsoDoWhateverIWant(MyParameterObject parameterObject)
    {
        string logMessage = ParameterValueMessage(parameterObject);
        Debug.Print(logMessage);
    }
    public static string ParameterValueMessage<T>(T arg)
    {
        return JsonConvert.SerializeObject(arg, Formatting.Indented);
    }
