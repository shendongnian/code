    Mock<CMath> mockedObj;
    CMath mathObj;
    [SetUp]
    public void Setup()
    {
        mockedObj = new Mock<CMath>();
        mockedObj.CallBase = true;
        mathObj = mockedObj.Object;
    }
    [Test]
    public void Factorial_Of4_CallsMultiply4Times()
    {
        mathObj.Factorial(4);
        mockedObj.Verify(x => x.Multiply(It.IsAny<double>(), 
                                         It.IsAny<double>()), Times.Exactly(4));
    }
