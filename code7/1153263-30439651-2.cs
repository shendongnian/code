    [TestMethod]
    public void Test()
    {
        var fakeHttpContext = new Mock<HttpContextBase>();
        var fake = new GenericIdentity("user");
        var prin = new GenericPrincipal(fakeIdentity, null);
        fakeHttpContext.Setup(t => t.User).Returns(prin);
        var data = new Mock<Data>(fakeHttpContext.Object);
        // Now you can successfully call data.GetData()
    }
