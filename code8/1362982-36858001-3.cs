    public static void Main()
    {
        Thread.Sleep(TimeSpan.FromMinutes(2));
        using (var tokenSource = new CancellationTokenSource())
        {
            var myTask = Task.Run( () => WorkerTask(tokenSource.Token))
            tokenSource.CancelAfter(TimerSpan.FromMinutes(5));
            // instead of LongToRun
            Task.Wait(myTask);
        }
    }
    public static async Task WorkerTask(CancellationToken token)
    {
        // repeatedly wait a while and DoWork():
        while (!token.IsCancellationRequested)
        {
            await Task.Delay(TimeSpan.FromMinutes(2, token);
            DoWork();
        }
    }
