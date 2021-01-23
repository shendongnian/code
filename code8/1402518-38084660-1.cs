    public void TestPrecisionSmall()
    {
        PRECISION = 5;
        decimal d = Precision(42);
        Assert.That(GetPrecision(d) == PRECISION);  // or >= if that's more appropriate
    }
