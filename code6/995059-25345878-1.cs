    [Test]
    [TestCase('1', ExpectedResult = 1)]
    [TestCase('a', ExpectedException = typeof(ArgumentException))]
    public int ChatToNumTest(char c)
    {
        return c.ToInt32();
    }
