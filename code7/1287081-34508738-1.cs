    private string path;
    [TestInitialize]
    public void InitTest()
    {
        string dir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName;
        path = dir + "\\data\\d.xml";
    }
    [TestMethod]
    [DeploymentItem("d.xml")]
    [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", path, "model", DataAccessMethod.Sequential)]
