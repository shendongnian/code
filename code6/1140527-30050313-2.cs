    [TestMethod]
    public void Test()
    {
        using(var datasourceObject = new DatasourceObject("location-string"))
        {
            datasourceObject.Connect();
            // Do some Stuff with Asserts
        }
    }
