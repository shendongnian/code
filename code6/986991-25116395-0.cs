    private static object[] TestValues = 
    {
        new object[]{ Decimal.MaxValue },
        new object[]{ Decimal.MinValue }
    };
    [TestCaseSource("TestValues")]
    public void FooTest(decimal value)
    {
        Assert.That(value, Is.EqualTo(Decimal.MaxValue));
    }
