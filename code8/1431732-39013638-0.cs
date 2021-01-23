    public virtual IEnumerable<TResult> ExecuteQuery<TResult>(
        TableQuery query,
        EntityResolver<TResult> resolver,
        TableRequestOptions requestOptions = null,
        OperationContext operationContext = null
    )
