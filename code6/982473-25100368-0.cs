    public class MyQueryableAttribute : QueryableAttribute
    {
        public override void ValidateQuery(HttpRequestMessage request, 
        ODataQueryOptions queryOptions)
        {
            if (!DoesCurrentUserHaveAccessToCustomers)
            {
                throw new ODataException("User cannot access Customer data");
            }
            base.ValidateQuery(request, queryOptions);
        }
    }
