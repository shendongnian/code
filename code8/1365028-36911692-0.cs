    tasks[0] = Task.Run(() => throwExceptionAfterOneSecond())
        .ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                // Throw the inner exception
                throw task.Exception.InnerException;
            }
    
            Console.WriteLine("ContinueWith()");
        });
