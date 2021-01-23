    /// <summary>
    /// Apply default user policy to the DBQuery that will be used by actions on this controller.
    /// The big one we support here is X-Filter HTTP headers, so now you can provide top level filtering in the header of the request 
    /// before the normal OData filter and query parameters are applied.
    /// This is useful when you want to use $apply and $filter together but on separate sets of conditions.
    /// </summary>
    /// <param name="dataTable">DBQuery to apply the policy to</param>
    /// <returns>Returns IQueryable entity query ready for processing with the headers applied (if any)</returns>
    private IQueryable<TEntity> ApplyUserPolicy(DbQuery<TEntity> dataTable)
    {
        // Proprietary Implementation of Security Tokens
        //var tokenData = SystemController.CurrentToken(Request);
        //IQueryable<TEntity> query = ApplyUserPolicy(dataTable, tokenData);
        IQueryable<TEntity> query = dataTable.AsQueryable();
        // Now try and apply an OData filter passed in as a header.
        // This means we are applying a global filter BEFORE the normal OData query params
        // ... we can filter before $apply and group by
        System.Collections.Generic.IEnumerable<string> filters = null;
        if (Request.Headers.TryGetValues("X-Filter", out filters))
        {
            foreach (var filter in filters)
            {
                //var expressions = filter.Split(',');
                //foreach (var expression in expressions)
                {
                    var expression = filter;
                    Dictionary<string, string> options = new Dictionary<string, string>()
                    {
                        { "$filter"  , expression },
                    };
                    var model = this.Request.ODataProperties().Model;
                    IEdmNavigationSource source = model.FindDeclaredEntitySet(this.GetEntitySetName());
                    var type = source.EntityType();
                    Microsoft.OData.Core.UriParser.ODataQueryOptionParser parser
                        = new Microsoft.OData.Core.UriParser.ODataQueryOptionParser(model, type, source, options);
                    var filterClause = parser.ParseFilter();     // parse $filter 
                    FilterQueryOption option = new FilterQueryOption(expression, new ODataQueryContext(model, typeof(TEntity), this.Request.ODataProperties().Path), parser);
                    query = (IQueryable<TEntity>)option.ApplyTo(query, new ODataQuerySettings());
                }
            }
        }
        return query;
    }
