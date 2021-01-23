    public async Task<string> Get(int id)
    {
        var t1 = RunViaQueueBackgroundWorkItem(ct => DoSomeTask1(ct));
        var t2 = RunViaQueueBackgroundWorkItem(ct => DoSomeTask2(ct));
        await Task.WhenAll(t1, t2);
        //...
    }
