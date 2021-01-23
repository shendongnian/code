    [TestCase(-10, 2, -5)]
    [TestCase(-1, 2, -0.5)]
    public void TestDivide(double a, double b, double result)
    {
        Assert.That(_uut.Divide(a, b), Is.EqualTo(result));
    }
    
    [TestCase(-1, 0)]
    public void TestDivideThrows(double a, double b)
    {
        Assert.That(() => _uut.Divide(a, b), Throws.TypeOf<ArgumentException>());
    }
