    [TestMethod]
    public void TestMethod1()
    {
        var target = new ValidateJsonAntiForgeryTokenAttribute();
        var requestMessage = new HttpRequestMessage();
        requestMessage.Headers.Add("X-Requested-With", new[] {"xmlhttprequest"});
        var fakeDescriptor = new Mock<HttpActionDescriptor>();
        var fakeContext = new HttpControllerContext {Request = requestMessage};
        var actionContext = new HttpActionContext(fakeContext, fakeDescriptor.Object);
        target.OnActionExecuting(actionContext);
        Assert.AreEqual(HttpStatusCode.Forbidden, actionContext.Response.StatusCode);
    }
