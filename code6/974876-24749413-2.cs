    IUnityContainer container = new UnityContainer();
    Mock<IBusinessLogicObject> businessLogicObject = new Mock<IBusinessLogicObject>();
    container.RegisterInstance<IBusinessLogicObject>(businessLogicObject.Object);
    businessLogicObject
        .Setup(bl => bl.SomeMethod("some-stub-parameter"))
        .Returns("some expected value")
    IObjectUnderTest subject = container.Resolve<IObjectUnderTest>();
    var emptyResult = subject.MethodToBeTested("some-stub-parameter", "another-value");
    Assert.AreEqual(string.Empty, emptyResult);
    var result = subject.MethodToBeTested("some-stub-parameter", "businessLogic");
    Assert.AreEqual("some expected value", result);
