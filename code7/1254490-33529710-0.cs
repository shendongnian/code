    static async Task MyAsyncMethod()
    {
        await Task.Delay(TimeSpan.FromSeconds(1));
        throw new TaskCanceledException("My lost cancellation reason");
    }
    static void Main()
    {
        var task = MyAsyncMethod();
        try
        {
            task.GetAwaiter().GetResult();
        }
        catch (TaskCanceledException exception)
        {
            Console.WriteLine(exception.GetType()); // TaskCanceledException
            Console.WriteLine(exception.Message); // My lost cancellation reason
            Console.WriteLine(task.Status); // Canceled
            Console.WriteLine(task.Exception == null); // true
        }
        Console.Read();
    }
