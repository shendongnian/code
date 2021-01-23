    [TestMethod]
    public void TestMethodForAppInstance() {
        var provider = new TestApplicationInstanceProvider();
        bool isCreated = provider.CreateNewProcess();
    
        Assert.AreEqual(isCreated, true);
    }
