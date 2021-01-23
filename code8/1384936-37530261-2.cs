    async Task<TResult> WaitForFirstCompleted<TResult>( IEnumerable<Task<TResult>> tasks )
    {
        var taskList = new List<Task<TResult>>( tasks );
        while ( taskList.Count > 0 )
        {
            Task<TResult> firstCompleted = await Task.WhenAny( taskList ).ConfigureAwait(false);
            if ( firstCompleted.Status == TaskStatus.RanToCompletion )
            {
                return firstCompleted.Result;
            }
            taskList.Remove( firstCompleted );
        }
        throw new InvalidOperationException( "No task completed successful" );
    }
