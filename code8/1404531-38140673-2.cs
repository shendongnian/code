    [TestMethod]
    public async Task AbortDelayedExecutionTest()
    {
        int timeout = 1000;
        var delayExecutor = new DelayedExecutor(timeout);
        Action func = new Action(() => Debug.WriteLine("Ran Action!"));
        var sw = Stopwatch.StartNew();
        Debug.WriteLine("sw.ElapsedMilliseconds outside DelayExecute 1: " + sw.ElapsedMilliseconds);
        Task delayTask = delayExecutor.DelayExecute(func);
        Thread.Sleep(100);
        delayExecutor.AbortExecution();
        await delayTask;
        Debug.WriteLine("sw.ElapsedMilliseconds outside DelayExecute 2: " + sw.ElapsedMilliseconds);
    }
