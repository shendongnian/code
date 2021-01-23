    static void Main(string[] args)
    {
        Console.WriteLine("main started on thread {0}", Thread.CurrentThread.ManagedThreadId);
        var testAsyncTask = Task.Run(() => testAsync());
        testAsyncTask.Wait();
    }
    static async Task testAsync()
    {
        Console.WriteLine("testAsync started on thread {0}", Thread.CurrentThread.ManagedThreadId);
        await Task.Delay(1000);
        Console.WriteLine("testAsync continued on thread {0}", Thread.CurrentThread.ManagedThreadId);
    }
