    public static void Main()
    {
        Action<object> action = e => Console.WriteLine(e);
        Execute(action);
    }
    
    private static void Execute(Action<string> action)
    {
        action("hello world");
    }
