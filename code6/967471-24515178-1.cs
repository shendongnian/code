    [Test]
    public void MethodA_StateThatYouAreTesting_ExpectedResult()
    {
        var partialMockA = new Mock<ClassA>{CallBase=True};
        var stubB = new Mock<ClassB>();
        stubB.Setup(b => b.SomeMethod()).Returns(SomeValue);
        parialMockA.Setup(a => a.CreateClassB()).Returns(stubB.Object);
        var result = partialMock.MethodA();
    
        Assert.AreEqual(someExpectedValue, result);
    }
