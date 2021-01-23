    static async Task Test()
    {
        Task t1 = StringAsync().ContinueWith(t => System.Console.Out.WriteLine("string"));
        Task t2 = IntAsync().ContinueWith(t => System.Console.Out.WriteLine("int"));
        Task t3 = ListAsync().ContinueWith(t => System.Console.Out.WriteLine("list"));
        await Task.WhenAny(t1, t2, t3); 
        // use WhenAll if you want to wait until all tasks are done
    }
