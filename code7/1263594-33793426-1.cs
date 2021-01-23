    private async Task<string> LoadHouseAsync(int i)
    {
        Debug.Print("Thread: " + Thread.CurrentThread.ManagedThreadId);
        await Task.Delay(5000); // simulate async I/O bound work
        return "House" + i;
    }
