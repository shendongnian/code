    private bool UrlMatchesRouteTable(string url, System.Web.Routing.RouteCollection routeTable)
    {
        var baseUri = new Uri("http://www.somedomain.com/", UriKind.Absolute);
        var uri = new Uri(baseUri, url);
        var request = new System.Web.HttpRequest(
            filename: string.Empty,
            url: uri.ToString(),
            queryString: string.IsNullOrEmpty(uri.Query) ? string.Empty : uri.Query.Substring(1));
        // Create a TextWriter with null stream as a backing stream 
        // which doesn't consume resources
        using (var nullWriter = new System.IO.StreamWriter(System.IO.Stream.Null))
        {
            var response = new System.Web.HttpResponse(nullWriter);
            var httpContext = new System.Web.HttpContext(request, response);
            var fakeHttpContext = new System.Web.HttpContextWrapper(httpContext);
            return routeTable.GetRouteData(fakeHttpContext) != null;
        }
    }
