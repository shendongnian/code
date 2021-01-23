    private const string Foo = "foobar";
    private HttpContext _httpContext = null;
    
    [TestInitialize]
    public void InitializeContext()
    {
        _httpContext = new HttpContext(new HttpRequest(
            null, "http://tempuri.org", null), new HttpResponse(null));
        _httpContext.Application["fooKey"] = Foo;
    }
    
    [TestMethod]
    public void Test1()     <-- **** Example Test Method ****
    {
        YourClassName cls = new YourClassName(_httpContext);
        cls.MethodUnderTest();
    }
    
    [TestCleanup]
    public void DisposeContext()
    {
        _httpContext = null;
    }
