    [TestMethod]
    public void HttpsFilter_Forbidden403_WithHttpWhenHttpsIsRequiredByAction()
    {
        HttpRequestMessage requestMessage = new HttpRequestMessage();
        requestMessage.SetRequestContext(new HttpRequestContext());
        requestMessage.RequestUri = new Uri("http://www.some-uri.com"); // note the http here (not https)
        HttpControllerContext controllerContext = new HttpControllerContext();
        controllerContext.Request = requestMessage;
        Mock<HttpControllerDescriptor> controllerDescriptor = new Mock<HttpControllerDescriptor>();
        controllerDescriptor.Setup(m => m.GetCustomAttributes<HttpsRequiredAttribute>()).Returns(new Collection<HttpsRequiredAttribute>()); // empty collection for controller
        Mock<HttpActionDescriptor> actionDescriptor = new Mock<HttpActionDescriptor>();
        actionDescriptor.Setup(m => m.GetCustomAttributes<HttpsRequiredAttribute>()).Returns(new Collection<HttpsRequiredAttribute>() { new HttpsRequiredAttribute() }); // collection has one attribute for action
        actionDescriptor.Object.ControllerDescriptor = controllerDescriptor.Object;
        HttpActionContext actionContext = new HttpActionContext();
        actionContext.ControllerContext = controllerContext;
        actionContext.ActionDescriptor = actionDescriptor.Object;
        HttpAuthenticationContext authContext = new HttpAuthenticationContext(actionContext, null);
        Func<Task<HttpResponseMessage>> continuation = () => Task.Factory.StartNew(() => new HttpResponseMessage() { StatusCode = HttpStatusCode.OK });
        HttpsFilter filter = new HttpsFilter();
        HttpResponseMessage response = filter.ExecuteAuthorizationFilterAsync(actionContext, new CancellationTokenSource().Token, continuation).Result;
        Assert.AreEqual(HttpStatusCode.Forbidden, response.StatusCode);
    }
