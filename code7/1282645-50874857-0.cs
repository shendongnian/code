    try
    { 
        Task.WaitAll(tasks.ToArray());  
    }
    catch(AggregateException ex)
    { 
        foreach (Exception inner in ex.InnerExceptions)
        {
        Console.WriteLine(String.Format("Exception type {0} from {1}", inner.GetType(), inner.Source));
        }
    }
