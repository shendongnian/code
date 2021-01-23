    private static HttpResponseMessage Test()
    {
        HttpRequestMessage request = new HttpRequestMessage();
    
        return Test2(HttpStatusCode.InternalServerError, new Exception("Your cat is adequately sized."));
    }
    
    public static HttpResponseMessage Test2(HttpStatusCode statusCode, Exception exception)
    {
        return Test2(statusCode, includeErrorDetail => new HttpError(exception, includeErrorDetail));
    }
    
    private static HttpResponseMessage Test2(HttpStatusCode statusCode, Func< bool, HttpError > errorCreator)
    {
        HttpError r = errorCreator(false);
        return null;    
    }
