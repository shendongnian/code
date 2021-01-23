    static async Task<bool> taskWrapper()
    {
        bool firstIn = await signal.WaitAsync(0);
        if (firstIn)
        {
            await baseTask();
            signal.Release();
        }
        else
        {
            await signal.WaitAsync();
            signal.Release();
        }
        return firstIn;
    }
