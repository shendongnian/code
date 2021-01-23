    private void Method(IEnumerable<String> list)
    {
        foreach(string str in list)
            Console.WriteLine(str);
    }
    
    private void Main()
    {
        Action<IEnumerable<String>> myAction = Method;
        string[] list = { "First", "Second", "Third" };
        myAction(list);
    }
