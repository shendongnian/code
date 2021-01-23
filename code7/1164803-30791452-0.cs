    // This will be set by the test framework.
    public TestContext TestContext { get; set; }
    [TestCleanup]
    public void AfterTest()
    {
        if (TestContext.CurrentTestOutcome != UnitTestOutcome.Passed) 
        {
            Driver.TakeScreenshot();
        }
    }
