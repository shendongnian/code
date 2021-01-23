    public async Task<bool> WaitOneSecondForClientConnect()
    {
        bool result = false;
        try
        {
            result = await WaitForConnectionAsyncSyncWrapper();
        }
        catch (Exception e)
        {
            log.Write("Error waiting for pipe client connect: " + e.Message);
        }
        return result;
    }
