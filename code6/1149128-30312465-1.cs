    public static XDocument Xml { get; set; }
    [DeploymentItem("input.xml")]
    [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
               "input.xml",
               "User",
                DataAccessMethod.Sequential)]
    [ClassInitialize()]
    public static void ClassInit(TestContext context)
    { // This is done only once and used by other tests.
        Xml = ...
        Assert.IsTrue(Xml.Node ... );
    }
