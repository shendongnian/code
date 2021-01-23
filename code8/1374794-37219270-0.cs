    private string myFunction()
    {
        string myStr = Task.Run(async () => await myDoWork()).Result;
        return myStr;
    }
    private async Task<string> myDoWork()
    {
        logger.Debug("Step 1");
        string answer = await aFunction();
        logger.Debug("Step 4");
        return answer;
    }
    public async Task<string> aFunction()
    {
        logger.Debug("Step 2");
        return await bFunction(CancellationToken.None);
    }
    AsyncLock myLock = new AsyncLock();
    public async Task<string> bFunction(CancellationToken cToken)
    {
        using (await myLock(cToken))
        {
            logger.Debug("Step 3");
            result = "Hello";
            return result;
        }
    }
