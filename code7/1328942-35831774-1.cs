    static Task<int> GetIntAsync()
    {
        return Task.Run(()=> GetIntSync());
    }
    static async Task RunItAsync()
    {
        // Should start the task, but should not block
        var task = GetIntAsync();
        Console.WriteLine("I'm writing something while the task is running...");
        // Should wait for the running task to complete and then output the result
        Console.WriteLine(await task);
    }
