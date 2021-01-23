    Task taskFunFiltering = null;
    
    private async Task ProcessFrame(...)
    {   // a new frame is arrived
        DoSomeProcessing(...);
        // only start a new run fun filtering if previous one is finished
        if (taskFunFiltering == null || taskFunFiltering.IsCompleted)
        {   // start a new fun filtering
            // don't wait for the result
            taskFunFiltering = Task.Run( () => ...);
        }
    }
    
    private async Task RunFunFiltering(...)
    {
        // do the filtering and wait until finished
        var filterResult = await DoFiltering(...);
        DisplayResult(filterResult);
    }
