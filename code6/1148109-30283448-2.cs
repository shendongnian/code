    static async Task JSSetTimeout(int ms, Action callback, int waitResolution = 10)
    {
        var startTime = DateTime.UtcNow;
        while ((DateTime.UtcNow - startTime).TotalMilliseconds < ms)
        {
            await Task.Delay(waitResolution);
        }
        Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        callback();
    }
