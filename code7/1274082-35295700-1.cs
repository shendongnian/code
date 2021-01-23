    using Models.Fakes;
    IDisposable shimsContext;
    [TestInitialize]
    public void SetUp()
    {
        shimsContext = ShimsContext.Create();
        ShimDBModel.Constructor = (@this) =>
        {
            ShimDBModel shim = new ShimDBModel(@this)
            {
                // here you can provide shim methods for DBModel
            };
        };
    }
    [TestCleanup]
    public void CleanUp()
    {
        // Let's do not forget to clean up shims after each test runs
        shimsContext.Dispose();
    }
