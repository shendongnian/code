    class RightsChecker
    {
        public Action AccessDeniedAction { get; set; }
        public RightsChecker(...)
        {
            ...
            AccessDeniedAction = () => Environment.Exit();
        }
    }
    [Test]
    public TestCheckRightsWithoutRights()
    {
        ...
        bool wasAccessDeniedActionExecuted = false;
        rightsChecker.AccessDeniedAction = () => { wasAccessDeniedActionExecuted = true; }
        ...
        Assert.That(wasAccessDeniedActionExecuted , Is.True);
    }
