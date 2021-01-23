    [TestCleanup]
    public virtual void Cleanup()
    {
        if (TestContext.CurrentTestOutcome != UnitTestOutcome.Passed && GlobalSetup.LastException != null)
        {
            var e = GlobalSetup.LastException;
            Log.Error(GlobalSetup.LastException, $"{e.GetType()}: {e.Message}\r\n{e.StackTrace}");
        }
    }
