    static void Main(string[] args)
    {
      Console.WriteLine("Main: " + Thread.CurrentThread.ManagedThreadId);
      MainAsync(args).Wait(); // Note: This is the same as "var task = MainAsync(args); task.Wait();"
      Console.WriteLine("Main End: " + Thread.CurrentThread.ManagedThreadId);
      Console.ReadKey();
    }
    static async Task MainAsync(string[] args)
    {
      Console.WriteLine("Main Async: " + Thread.CurrentThread.ManagedThreadId);
      await thisIsAsync(); // Note: This is the same as "var task = thisIsAsync(); await task;"
    }
    private static async Task thisIsAsync()
    {
      Console.WriteLine("thisIsAsyncStart: " + Thread.CurrentThread.ManagedThreadId);
      await Task.Delay(1); // Note: This is the same as "var task = Task.Delay(1); await task;"
      Console.WriteLine("thisIsAsyncEnd: " + Thread.CurrentThread.ManagedThreadId);
    }
