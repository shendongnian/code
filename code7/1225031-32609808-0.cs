    public async Task<RES> PostAsync<RES>(string url, string content) where RES : new()
    {
        // start the task that will call PostAsync:
        var postTask = Task.Run( () => PostAsync(url, content));
        // while this task is running you can do other things
        // once you need the result: wait for the task to finish:
        postTask.Wait();
        // If needed check Task.IsFaulted / Task.IsCanceled etc. to check for errors
        
        // the returned value is in Task.Result:
        return postTask.Result;
    }
