    public class SnakeCaseActionSelector : ApiControllerActionSelector
    {
        public override HttpActionDescriptor SelectAction(HttpControllerContext controllerContext)
        {
            var newUri = CreateNewUri(
                controllerContext.Request.RequestUri, 
                controllerContext.Request.GetQueryNameValuePairs());
            controllerContext.Request.RequestUri = newUri;
            return base.SelectAction(controllerContext);
        }
        private Uri CreateNewUri(Uri requestUri, IEnumerable<KeyValuePair<string, string>> queryPairs)
        {
            var currentQuery = requestUri.Query;
            var newQuery = ConvertQueryToCamelCase(queryPairs);
            return new Uri(requestUri.ToString().Replace(currentQuery, newQuery));
        }
        private static string ConvertQueryToCamelCase(IEnumerable<KeyValuePair<string, string>> queryPairs)
        {
            queryPairs = queryPairs
                .Select(x => new KeyValuePair<string, string>(x.Key.ToCamelCase(), x.Value));
            return "?" + queryPairs
                .Select(x => String.Format("{0}={1}", x.Key, x.Value))
                .Aggregate((x, y) => x + "&" + y);
        }
    }
