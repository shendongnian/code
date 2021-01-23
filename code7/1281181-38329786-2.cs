        public class FullTextSearchAttribute : EnableQueryAttribute
        {
            public override IQueryable ApplyQuery(IQueryable queryable, ODataQueryOptions queryOptions)
            {
                if (queryOptions.Filter == null)
                   return queryOptions.ApplyTo(queryable);
                const string pattern = "contains\\([%20]*[^%27]*[%20]*,[%20]*%27(?<Value>[^%27]*)";
                var matchEvaluator = new MatchEvaluator(match =>
                {
                    var value = match.Groups["Value"].Value;
                    return match.Value.Replace($"%27{value}", $"%27-FTSPREFIX-{value}");
                });
                var request = new HttpRequestMessage(HttpMethod.Get, 
                          Regex.Replace(queryOptions.Request.RequestUri.AbsoluteUri,
                              pattern,
                              matchEvaluator,
                              RegexOptions.IgnoreCase));
                return new ODataQueryOptions(queryOptions.Context, request).ApplyTo(queryable);
            }
        }
