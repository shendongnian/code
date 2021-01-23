    public Resource GetResource()
    {
        var tcs = new TaskCompletionSource<Resource>();
        var storedTask = Interlocked.CompareExchange(ref task, tcs.Task, null);
        if (storedTask == null)
        {
            var resource = Task.Factory.StartNew<Resource>(CreateResource).Result;
            tcs.SetResult(resource);
            return resource;
        }
        else
        {
            return storedTask.Result;
        }
    }
