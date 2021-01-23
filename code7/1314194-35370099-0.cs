    static void Main(string[] args)
    {
        SynchronousCall();
        Task.WaitAll(Test(), Test2());
        var s = CallContext.LogicalGetData("SynchronousCall");
        var test = CallContext.LogicalGetData("Test");
        var test2 = CallContext.LogicalGetData("Test2");
        Console.WriteLine("s val: {0}", (s == null) ? "{null}" : s);
        Console.WriteLine("test val: {0}", (test == null) ? "{null}" : test);
        Console.WriteLine("test2 val: {0}", (test2 == null) ? "{null}" : test2);
    }
    private static void SynchronousCall()
    {
        CallContext.LogicalSetData("SynchronousCall", true);
    }
    private static async Task<bool> Test()
    {
        CallContext.LogicalSetData("Test", true);
        var b = await Task.Run<bool>(() => 
        {
            return true; 
        });
        return b;
    }
    private static async Task<bool> Test2()
    {
        CallContext.LogicalSetData("Test2", true);
        var b = await Task.Run<bool>(() =>
        {
            return true;
        });
        return b;
    }
