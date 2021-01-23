    [TestMethod]
    public void TestMethod1()
    {
        using (ShimsContext.Create())
        {
            ShimExternalClass.AllInstances.ToString01 = () =>
            {
                return String.Empty();
            };
            Assert.IsNull(new ExternalClass().ToString());
        }
    }
