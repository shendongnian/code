    [TestInitialize]
    public void SetUp()
    {
        Container = new WindsorContainer();
        // register your dependencies
    }
    [TestCleanup]
    public void Cleanup()
    {
        Container.Dispose();
    }
