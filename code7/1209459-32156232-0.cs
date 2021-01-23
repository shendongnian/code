    [TestMethod]
    public void SayHelloJohn_ShouldUseServiceProxy()
    {
        const string EXPECTED_RESULT = "Hello John";
        const string NAME = "John";
        var fakeServiceProxy = new Mock<IServiceProxy>(MockBehavior.Strict);
        var fakeFooBar = new Mock<IFooBar>(MockBehavior.Loose);
        fakeFooBar.Setup(bar => bar.Hello(NAME)).Returns(EXPECTED_RESULT);
        fakeServiceProxy.Setup(proxy => proxy.FooService(
                        It.IsAny<ServiceProxy.FooServiceDelegate>()))
                        .Callback<ServiceProxy.FooServiceDelegate>(arg => arg(fakeFooBar.Object));
        var target = new DoFoo(fakeServiceProxy.Object);
        var result = target.SayHello(NAME);
        Assert.AreEqual(EXPECTED_RESULT, result);
    }
