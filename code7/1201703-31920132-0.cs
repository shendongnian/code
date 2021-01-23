    public static Task SwallowExceptions(this Task task)
    {
        return task.ContinueWith(_ => { });
    }
    
    faultedTask.SwallowExceptions().Wait();
    if (faultedTask.IsFaulted)
    {
        // handle exception
    }
