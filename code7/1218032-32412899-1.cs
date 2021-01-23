    static Task<int> TestAsync(int c)
    {
        var tcs = new TaskCompletionSource<int>();
        if (c < 0)
            tcs.SetResult(0);
        else
        {
            Task.Run(() =>
            {
                var t = TestAsync(c - 1);
                t.ContinueWith(_ => tcs.SetResult(0), TaskContinuationOptions.ExecuteSynchronously);
            });
        }
        return tcs.Task;
    }
    static void Main(string[] args)
    {
        Task.Run(() => TestAsync(2000).ContinueWith(_ =>
        {
              //breakpoint here - look at the stack
        }, TaskContinuationOptions.ExecuteSynchronously)).GetAwaiter().GetResult();
    }
