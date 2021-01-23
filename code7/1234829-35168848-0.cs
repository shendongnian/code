    public class SecureEnableQueryAttribute : EnableQueryAttribute
    {
        public virtual void ValidateQuery(HttpRequestMessage request, ODataQueryOptions queryOptions)
        {
            base.ValidateQuery(request, queryOptions);
            // Insert custom logic, possibly looking at queryOptions.SelectExpand
            // or queryOptions.RawValues.
        }
    }
