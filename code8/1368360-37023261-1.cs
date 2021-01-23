    void Fn()
    {
        var task = Task.FromResult(true);
        Console.WriteLine(task.IsCompleted); // prints true.
        Console.WriteLine(task.Result); // prints true. a ""blocking"" API
    }
