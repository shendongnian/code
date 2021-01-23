    public double Factorial(int a, Func<double,double,double> multiply = null)
    {
        multiply = multiply ?? CMath.Multiply;
        double factorial = 1.0;
        for (int i = 1; i <= a; i++)
            factorial = multiply(factorial, i);
        return factorial;
    }
    [Test]
    public void Factorial_Of4_CallsMultiply4Times()
    {
        var mathMock = new Mock<IMath>();
        var math = new CMath();
        math.Factorial(4, mathMock.Object.Multiply);
        mathMock.Verify(x => x.Multiply(It.IsAny<double>()), Times.Exactly(4));
    }
