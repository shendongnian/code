    [TestMethod]
    public void WebServiceTest01(){
        BusinessLogic bs = new BusinessLogic();
        var result = await bs.CallWebService();
        Assert.NotNull(result);
    }
