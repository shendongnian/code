    [Test]
    public void Test1()
    {
        // sometest code
        TestJS();
    }
    [Test]
    public void Test2()
    {
        // some other test code
        TestJS();
    }
    public void TestJS()
    {
        Assert.Fail("Or whatever to test the JS");
    }
    [TearDown]
    public void TearDown()
    {
        if (TestContext.CurrentContext.Result.Status != TestStatus.Passed)
        {
            Driver.TakeScreenshot(TestContext.CurrentContext.Test.Name, "Failed");
        }
    }
