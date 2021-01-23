    public HttpResponseMessage Get()
    {
       var domain =  Request.Headers.Referrer?.GetLeftPart(UriPartial.Authority);
        ...
    }
