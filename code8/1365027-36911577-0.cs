    var tasks = new Task[1];
    tasks[0] = Task.Run(() => throwExceptionAfterOneSecond());
    
    // For error handling.
    tasks[0].ContinueWith(task =>
        {
            // Your logic to handle the exception goes here
    
            // Aggregate exception
            Console.WriteLine(task.Exception.Message);
    
            // Inner exception, which is your custom exception
            Console.WriteLine(task.Exception.InnerException.Message);
        },
        TaskContinuationOptions.OnlyOnFaulted);
    
    // If it succeeded.
    tasks[0].ContinueWith(task => 
    {
        // success
        Console.WriteLine("ContinueWith()");
    },TaskContinuationOptions.OnlyOnRanToCompletion);
