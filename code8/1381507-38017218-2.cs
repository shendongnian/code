    /// <summary>
    /// Applies the query to the given IQueryable based on incoming query from uri and
    /// query settings. 
    /// </summary>
    /// <param name="queryable">The original queryable instance from the response message.</param>
    /// <param name="queryOptions">The System.Web.OData.Query.ODataQueryOptions instance constructed based on the incomming request</param>
    public override IQueryable ApplyQuery(IQueryable queryable, ODataQueryOptions queryOptions)
    {
        // TODO: add your custom logic here
        return base.ApplyQuery(entity, options);
    }
