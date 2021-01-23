    [DataSource(@"Provider=Microsoft.SqlServerCe.Client.4.0; Data Source=C:\Data\MathsData.sdf;", "Numbers")]
    [Test]
    static public void NUnitWriter()
    {
        int x = 0
        int errorCode = Convert.ToInt32(TestContext.DataRow["ErrorCode"]);
        Assert.AreEqual (x, errorCode);
    }  
