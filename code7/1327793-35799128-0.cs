    public Task<Result> ExecuteAsync( Paramerters parameters ) {
        List<Task> tasks = new List<Task>();
        foreach(var param in parameters)
        {
            var task = ExecuteSomethingElseAsync(param);
            tasks.Add(task);
        }
        Task.WhenAll(tasks.ToArray());
    }
