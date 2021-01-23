    public async Task Start()
    {
        const int MaxNumberOfTries = 10;
        List<Task<bool>> tasks = new List<Task<bool>>();
        for (int i = 0; i < 1000; i++)
        {
            tasks.Add(this.QueryWithRetry(i, MaxNumberOfTries));
        }
        await Task.WhenAll(tasks);
    }
    public async Task<bool> QueryWithRetry(int i, int numOfTries)
    {
        int tries = 0;
        bool result;
        do
        {
            result = await Query(i);
            tries++;
        } while (!result && tries < numOfTries);
        return result;
    }
