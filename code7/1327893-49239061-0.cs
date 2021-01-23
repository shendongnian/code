    private static void ValueChanged(AsyncLocalValueChangedArgs<string> obj)
    {
        Console.WriteLine(obj.CurrentValue);
    }
    public static void Main(string[] args)
    {
        ExecutionContext.SuppressFlow();
        AsyncLocalContext.Value = "Main";
        Task.Run(() =>
            {
                AsyncLocalContext.Value = "Test1";
            }).Wait();
        Console.WriteLine("Main: " + AsyncLocalContext.Value);
    }
