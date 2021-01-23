    // Your method with the *special* parameter.
    private void ChrisMethod(Action<IEnumerable<String>> method)
    {
        string[] exampleList = { "First", "Second", "Third" };
        method(exampleList);
    }
    // The method that can be used as parameter.    
    private void ParameterMethod(IEnumerable<String> list)
    {
        foreach(string str in list)
            Console.WriteLine(str);
    }
    
    public void Main()
    {
        ChrisMethod(ParameterMethod);
    }
