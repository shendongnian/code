    // Define how many tasks will be run via ExcelAsyncUtil
    var countdownEvent = new CountdownEvent(2);
    
    ExcelAsyncUtil.Run("Task1", null, handle =>
    {
        try
        {
            // Do work for Task 1
        }
        finally
        {
            countdownEvent.Signal();
        }
    });
    
    ExcelAsyncUtil.Run("Task2", null, handle =>
    {
        try
        {
            // Do work for Task 2
        }
        finally
        {
            countdownEvent.Signal();
        }
    });
    
    // Wait for all of them to finish (blocking)
    countdownEvent.Wait();
                
    // All async tasks have been completed
    // (...)
