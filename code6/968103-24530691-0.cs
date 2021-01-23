    public async void CallerAsyncMethod()
    {
        var taskResult = Task.Factory.StartNew(() => IntensiveMethod());
        await taskResult;
    }
