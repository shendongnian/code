    [TestCase(4, 24)]
    [TestCase(2, 2)]
    [TestCase(1, 1)]
    [TestCase(0, 1)]
    public void Factorial_OfInput_ShouldReturnExpected(int input, int expectedResult)
    {
        Assert.That(mathObj.Factorial(input), Is.EqualTo(expectedResult));
    }
