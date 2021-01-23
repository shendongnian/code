    public Task<List<Bar>> RequestDataAsync()
    {
        var tcs = new TaskCompletionSource<List<Bar>>();
        //This does not need to be on a separate thread, it finishes fast.
        CONNECTION.ReqBarData(tcs);
        return tcs.Task;
    }
    
    virtual override void OnBar(List<Bar> someBars, object stateInfo)
    {
        //We get our TaskCompletionSource object back from the state paramter
        var tcs = (TaskCompletionSource<List<Bar>>)stateInfo;
        //we set the result of the task.
        tcs.SetResult(someBars);
    }
