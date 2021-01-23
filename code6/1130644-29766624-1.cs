    public async Task<object> Invoke(Query query)
    {
        var queryHandlerType = typeof(IQueryHandler<,>);
        var queryType = query.GetType();
        var queryResultType = queryType.BaseType.GetGenericArguments().First();
        var handler = _container.GetInstance(queryHandlerType.MakeGenericType(queryType, queryResultType)) as dynamic;
        return await handler.Handle(query as dynamic);
    }
