    public override bool TestMethod()
    {
        var task = Task.Run(async () => {
           return await engine.DoAsyncFunction();
        });
       var Result = task.Result; // use returned result from async method here
    }
