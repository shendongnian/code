    try
    {
        // like above 
    }
    catch(TaskCanceledException e)
    {
        Debug.WriteLine("Task cancelled: " + e.Message);
    }
    finally
    {
        deferral.Complete();
    }
