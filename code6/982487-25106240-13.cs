    public class SecureAccessAttribute : EnableQueryAttribute
    {
        public override void ValidateQuery(HttpRequestMessage request, ODataQueryOptions queryOptions)
        {
            if(queryOptions.SelectExpand != null
                && queryOptions.SelectExpand.RawExpand != null
                && queryOptions.SelectExpand.RawExpand.Contains("Orders"))
            {
                //Check here if user is allowed to view orders.
                throw new InvalidOperationException();
            }
            base.ValidateQuery(request, queryOptions);
        }
    }
