    [TestMethod]
    public void TestMethod1()
    {
        var target = new ValidateJsonAntiForgeryTokenAttribute();
        var requestMessage = new HttpRequestMessage();
        requestMessage.Headers.Add("X-Requested-With", new[] {"xmlhttprequest"});
        var fakeDescriptor = new Mock<HttpActionDescriptor>();
        var controllerContext = new HttpControllerContext {Request = requestMessage};
        var context = new HttpActionContext(controllerContext, fakeDescriptor.Object);
        target.OnActionExecuting(context);
        Assert.AreEqual(HttpStatusCode.Forbidden, actionContext.Response.StatusCode);
    }
