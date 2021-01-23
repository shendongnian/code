    [TestMethod]
    public void Test()
    {
        try
        {
            var datasourceObject = new DatasourceObject("location-string");
            datasourceObject.Connect();
            // Do some Stuff with Asserts
        }
        finally
        {
            datasourceObject.Disconnect(); // must be executed
        }
    }
