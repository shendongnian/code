    [Test]
    // These are all "zero" values.
    [TestCase(0, true)]
    [TestCase(TypeCode.Empty, true)]
    [TestCase(StringComparison.CurrentCulture, true)]
    // These are not
    [TestCase(TypeCode.Byte, false)]
    [TestCase(StringComparison.InvariantCulture, false)]
    public void Value_IsEquivalentTo_Zero<T>(T value, bool expectedResult)
    {
        // Quick n dirty conversion of 0 to T
        T zero = (T)(object)0;
        Assert.AreEqual(expectedResult, value.Equals(zero));
    }
