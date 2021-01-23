    [TestMethod]
    public void TestMethodForAppInstance() {
        var resolver = new TestAssemblyResolver();
        var provider = new ApplicationInstanceProvider(resolver);
        bool isCreated = provider.CreateNewProcess();
    
        Assert.AreEqual(isCreated, true);
    }
