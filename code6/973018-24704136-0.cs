    public static IObservable<QueryResult<TResult>> QueryPages<TResult>(this ForceClient forceClient, string query)
    {
        return Observable.FromAsync(() => forceClient.QueryAsync<TResult>(query))
            .Where(QueryResultIsValid)
            .Expand(result =>
                Observable.FromAsync(() => forceClient.QueryContinuationAsync<TResult>(queryResult.nextRecordsUrl))
                    .Where(QueryResultIsValid)
            );
    }
    public static bool QueryResultIsValid(QueryResult<TResult> result)
    {
        return result != null;
    }
