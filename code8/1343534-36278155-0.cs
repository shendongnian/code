    [TestMethod]
    public void TestMethod1()
    {
        using (ShimsContext.Create())
        {
            ShimCloudBlockBlob.AllInstances.<the method you want to override>  = (<the method arguments>) => {};
        }
    }
