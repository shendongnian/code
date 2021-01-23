    var sut = new MyController();
    // The HeaderDictionary is needed for adding HTTP headers to the response.
    // This needs a couple of different Mocks, because many properties in the class model are read-only.
    var headerDictionary = new HeaderDictionary();
    var response = new Mock<HttpResponse>();
    response.SetupGet(r => r.Headers).Returns(headerDictionary);
    var httpContext = new Mock<HttpContext>();
    httpContext.SetupGet(a => a.Response).Returns(response.Object);
    sut.ActionContext = new ActionContext()
    {
        HttpContext = httpContext.Object
    };
