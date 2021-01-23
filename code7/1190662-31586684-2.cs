    public async void YourMethod()
    {
        // 1. Blocks UI thread
        Task t = WriteToFile("text");
        t.Wait();
        // or
        // 2. Does not block UI thread
        await WriteToFile("text");
    }
