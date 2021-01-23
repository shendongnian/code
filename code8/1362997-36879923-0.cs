    using System.Net.Http;
    using System.Web.OData;
    using System.Web.OData.Query;
    
    public class SecureApiQueryAttribute : EnableQueryAttribute
    {
        public override void ValidateQuery(HttpRequestMessage request, ODataQueryOptions queryOptions)
        {
            base.AllowedQueryOptions = AllowedQueryOptions.None;
            base.PageSize = 30;
            base.AllowedFunctions = AllowedFunctions.AllFunctions;
            base.ValidateQuery(request, queryOptions);
        }
    }
