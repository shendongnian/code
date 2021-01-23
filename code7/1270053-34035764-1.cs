    async Task<int> SomeFunction()
    {
        var result1 = await FirstTaskFunction();
        var result2 = await SecondTaskFunction(result1);
        var result3 = await ThirdTask(result2);
        ...ad nausum..
    }
    async Task<> ThirdTaskFunction(SecondTaskResult x)
    {
        foreach(var device in devices)
        {
           await DoStuffToZWave(device);
        }
    }
    public Task<T> DoStuffToZWave(device) //NOTICE LACK OF ASYNC
    {
        var tcs = new TaskCompletionSource<T>()
        //Do stuff
        foo.callback += (o, e) => tcs.SetResult(theResult);
        return tcs.Task;
    }
