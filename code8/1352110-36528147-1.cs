    [Test]
    public void Factorial_Of4_CallsMultiply4Times()
    {
        var mathMock = new Mock<IMath>();
        var factorial = new Factorial();
        factorial.Factorial(4, mathMock.Object);
        mathMock.Verify(x => x.Multiply(It.IsAny<double>()), Times.Exactly(4));
    }
