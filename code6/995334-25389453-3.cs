    public async void BeginRead()
    {
        while (true)
        {
            await semaphore.WaitAsync();
            int result = await client.GetStream().WhenRead(null, 0, 0);
            semaphore.Release();
            DoStuffWithResult(result);
        }
    }
