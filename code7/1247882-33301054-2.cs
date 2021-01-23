    public Resource GetResource()
    {
        var tcs = new TaskCompletionSource<Resource>();
        var storedTask = Interlocked.CompareExchange(ref task, tcs.Task, null);
        if (storedTask == tcs.Task)
        {
            var resource = Task.Factory.StartNew<Resource>(CreateResource).Result;
            currentTcs.SetResult(resource);
        }
        return storedTask.Result;
    }
