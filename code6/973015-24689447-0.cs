    public static IObservable<QueryResult<TResult>> QueryPages<TResult>(this ForceClient forceClient, string query)
    {
        return Observable.Create(async (IObserver<QueryResult<TResult>> o, token) =>
        {
            // No need for try/catch.  Create() will call OnError if your task fails.
            // Also no need for OnCompleted().  Create() calls it when yout task completes
            var queryResult = await forceClient.QueryAsync<TResult> (query);
            while (!token.IsCancellationRequested && queryResult != null)
            {
                o.OnNext (queryResult);
                if (string.IsNullOrEmpty(queryResult.nextRecordsUrl))
                {
                    break;
                }
                queryResult = await forceClient.QueryContinuationAsync<TResult> (queryResult.nextRecordsUrl);
            }
            // No need to return anything.  Just the Task itself is all that Create() wants.
        }
    });
    // Usage:
    var forceClient = // ...
    var foos = forceClient.QueryPages<Foo>("SELECT A, B, C FROM Foo");
