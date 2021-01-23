    static void Main(string[] args)
    {
        var p = new Program();
        var c1 = new Class1();
        var c2 = new Class2();
        var cancellationTokenSource = new CancellationTokenSource();
        var someTask = c1.SomeTask(cancellationTokenSource.Token);
        var continuousTask = c2.ContinuouslyTask(cancellationTokenSource.Token); 
        while (Console.ReadKey().Key != ConsoleKey.Enter) { }
        cancellationTokenSource.Cancel();
        Task.WaitAll(someTask, continuousTask);
        p.Logout();
    }
