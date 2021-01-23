    public void IDoWhateverIWant(MyType data, int count, string message)
    {
        string logMessage = 
            ParameterValueMessage(data, "data") + Environment.NewLine +
            ParameterValueMessage(count, "count") + Environment.NewLine +
            ParameterValueMessage(message, "message");
        Debug.Print(logMessage);
    }
    public static string ParameterValueMessage<T>(T arg, string name)
    {
        string result = JsonConvert.SerializeObject(arg, Formatting.Indented);
        return name + ": " + result;    
    }
