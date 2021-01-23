    [setup]
    public void testInit()
    {
         target = new GetToken();
    }
    [Test]
    public void GetToken_StatusCode()
    {
        var expectedValue = "RipSnorter";
        target.TokenStatusCode = expectedValue;
        Assert.AreEquals(expectedValue, target.TokenStatusCode);
    }
