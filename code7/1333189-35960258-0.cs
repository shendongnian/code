    [Test]
    [TestCase(DataValue.A, false)]
    [TestCase(DataValue.B, false)]
    [TestCase(DataValue.C, false)]
    [TestCase(DataValue.F, true)]
    [TestCase(DataValue.G, true)]
    [TestCase(DataValue.H, true)]
    public void Test(DataValue argData, bool expectedResult)
    {
        var c = new YourClass();
        var arg = new MyArgument();  // set values in arg as appropriate
        var actualResult = c.Execute(arg);
        Assert.AreEqual(expectedResult, actualResult);
    }
