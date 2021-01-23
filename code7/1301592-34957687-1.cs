    public CallerInfo GetFrom(HttpRequest request)
    {
        return ExtractCallerInfo(request.QueryString);
    }
    public CallerInfo GetFromHttpContext()
    {
        return GetFrom(HttpContext.Current.Request);
    }
