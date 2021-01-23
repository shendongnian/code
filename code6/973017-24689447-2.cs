    public static IObservable<QueryResult<TResult>> QueryPages<TResult>(this ForceClient forceClient, string query)
    {
        return Observable.Create<QueryResult<T>> (async (observer, token) =>
        {
            // No need for try/catch.  Create() will call OnError if your task fails.
            // Also no need for OnCompleted().  Create() calls it when your task completes
            var queryResult = await forceClient.QueryAsync<TResult> (query);
            while (queryResult != null)
            {
                observer.OnNext (queryResult);
                // check the token *after* we call OnNext
                // because if an observer unsubscribes
                // it typically occurs during the notification
                // e.g. they are using .Take(..) or
                // something.
                if (string.IsNullOrEmpty(queryResult.nextRecordsUrl) ||
                    token.IsCancellationRequested)
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
