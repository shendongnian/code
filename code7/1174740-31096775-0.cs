    public static void Main(string[] args)
    {
        Task t = Task.Delay(10000);
        new Thread(() => { ThreadRun(t); }).Start();
        new Thread(() => { ThreadRun(t); }).Start();
        Console.WriteLine("Main thread exits"); // this prints immediately.
    }
    private static void ThreadRun(Task t)
    {
        t.Wait();
        Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " finished waiting"); // this prints about 10 seconds later.
    }
