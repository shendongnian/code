    [RESTRoute(Method = HttpMethod.GET, PathInfo = @"^/product")]
    public void MultiplyTwoIntegers(HttpListenerContext context)
    {
        var x = context.Request.QueryString["x"];
        var y = context.Request.QueryString["y"];
        // Verify the inputs and do the math.
    }
