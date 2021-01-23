    [Test]
    [TestCase(DataValue.A, false)]
    [TestCase(DataValue.B, false)]
    [TestCase(DataValue.C, false)]
    [TestCase(DataValue.F, true)]
    [TestCase(DataValue.G, true)]
    [TestCase(DataValue.H, true)]
    public void GetExpectedValueWhenConditionIsTrue(DataValue argData, bool expectedResult)
    {
        var c = new YourClass();
        var arg = new MyArgument { Condition = true, Data = argData };
        var actualResult = c.Execute(arg);
        Assert.AreEqual(expectedResult, actualResult);
    }
