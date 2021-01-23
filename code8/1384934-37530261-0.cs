        async Task<TResult> WaitForFirstCompleted<TResult>( IEnumerable<Task<TResult>> tasks )
        {
            var taskList = new List<Task<TResult>>( tasks );
            Task<TResult> firstCompleted;
            while ( taskList.Count > 0 )
            {
                firstCompleted = await Task.WhenAny( taskList );
                if ( firstCompleted.Status == TaskStatus.RanToCompletion )
                {
                    return firstCompleted.Result;
                }
                taskList.Remove( firstCompleted );
            }
            throw new InvalidOperationException( "No task completed successful" );
        }
