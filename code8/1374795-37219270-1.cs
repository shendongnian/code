    private string myFunction()
    {
        // This is NOT good style - you should avoid blocking on the result of a task.
        string myStr = Task.Run(async () => await myDoWork()).GetAwaiter().GetResult();
        return myStr;
    }
    private async Task<string> myDoWork()
    {
        logger.Debug("Step 1");
        string answer = await aFunction();
        logger.Debug("Step 4");
        return answer;
    }
    public Task<string> aFunction()
    {
        logger.Debug("Step 2");
        return bFunction(CancellationToken.None);
    }
    AsyncLock myLock = new AsyncLock();
    public async Task<string> bFunction(CancellationToken cToken)
    {
        using (await myLock(cToken))
        {
            logger.Debug("Step 3");
            return "Hello";
        }
    }
