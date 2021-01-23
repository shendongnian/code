    // Create a fake HttpContext using your URL
    var uri = new Uri("http://hostname/controller/action", UriKind.Absolute);
    var request = new HttpRequest(
        filename: string.Empty,
        url: uri.ToString(),
        queryString: string.IsNullOrEmpty(uri.Query) ? string.Empty : uri.Query.Substring(1));
    // Create a TextWriter with null stream as a backing stream 
    // which doesn't consume resources
    using (var nullWriter = new StreamWriter(Stream.Null))
    {
        var response = new HttpResponse(nullWriter);
        var httpContext = new HttpContext(request, response);
        var fakeHttpContext = new HttpContextWrapper(httpContext);
        // Use the RouteTable to parse the URL into RouteData
        var routeData = RouteTable.Routes.GetRouteData(fakeHttpContext);
        var values = routeData.Values;
        // The values dictionary now contains the keys and values
        // from the URL.
        // Key          | Value
        //
        // controller   | controller
        // action       | action
        // id           | {}
    }
