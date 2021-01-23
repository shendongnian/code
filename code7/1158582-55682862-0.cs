    // OData framework's EnableQuery attribute will apply query's again, after we have already applied the query to the result set
    // (So For e.g. you will get Top and Skip applied again on your results that have already had top and skip applied
    // this is a workaround the disables client side queries until this is fixed.
    // https://github.com/OData/WebApi/issues/159
    public class EnableCustomQueryAttribute : EnableQueryAttribute
    {
        public override IQueryable ApplyQuery(IQueryable queryable, ODataQueryOptions queryOptions)
        {
            return queryable;
        }
    }
