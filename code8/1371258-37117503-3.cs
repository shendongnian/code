    public async Task<T> DoAfter<T>(TimeSpan waitFor, Func<Logger, Task<T>> action)
    {
        await Task.Delay(waitFor);
        DatabaseLogger logger = new DatabaseLogger();
        logger.Log("Executing " + action.Method.Name + ", " + DateTime.Now.ToLongTimeString());
        try
        {
            return await action(logger);
            logger.Log("Successfully executed " + action.Method.Name + ", " + DateTime.Now.ToLongTimeString());
        }
        catch (Exception e)
        {
            logger.Log("Error in " + action.Method.Name + ": " + e.Message + ", " + DateTime.Now.ToLongTimeString());
        }
        finally
        {
            logger.CloseDatabase();
        }
    }
    private async Task MyAction(Logger logger)
    {
        var result = await MyMethod();
        logger.Log(result);
    }
    private async Task<string> MyMethod()
    {
        await Task.Delay(20000);
        return "Test";
    }
