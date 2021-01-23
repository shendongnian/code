    public MockHttpContext()
    {
        //MOCK System.Web
        _indirectionsContext = new IndirectionsContext();
        var httpRequest = new HttpRequest("", "http://www.monsite.com", "");
        var httpContext = new HttpContext(httpRequest, new HttpResponse(new StringWriter()));
        var applicationState = httpContext.Application;
        System.Web.Prig.PHttpContext.CurrentGet().Body = () => httpContext;
        System.Web.Prig.PHttpContext.ApplicationGet().Body = context => applicationState;
    }
