    private Foo datasourceObject;
    [TestInitialize]
    public void TestInitialize()
    {
        this.datasourceObject = new DatasourceObject("location-string");
        this.datasourceObject.Connect();
    }
    [TestMethod]
    public void Test()
    {
        // Do some Stuff with Asserts
    }
    [TestCleanup]
    public void TestCleanup()
    {
        this.datasourceObject.Disconnect();
    }
