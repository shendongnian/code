    private async Task<int> DoSomethingElseAsync()
    {
        Task<int> taskX = DoXAsync();  // no await, continue with next statement
        Task<int> taskY = DoYAsync();  // no await, continue with next statement
    
        // now await until both tasks finished and use the result
        // for an await we need a Task or a Task<TResult>
        // Task.WaitAll is not suitable: it returns void
        // Task.WhenAll returns a Task. we can await for that
        await Task.WhenAll( new Task<int>[] {taskX, taskY});
        // the results of the task are in Task.Result.
        // note that only Task<TResult> has a Result.
        // Task is the async version of void return, so no result
        return await DoZAsync(taskX.Result, taskY.Result);
    }
