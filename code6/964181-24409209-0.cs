    try
    {
        Task task = Task.Factory.StartNew(Work);
        task.Wait();
    }
    catch (AggregateException ex)
    {
        Console.WriteLine(ex.ToString());
    }
