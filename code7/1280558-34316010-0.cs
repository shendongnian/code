    [TestMethod()]
    public void CreateCustomerRelationsTest()
    {  
        var manager = new CustomerManager(MockRepository.GenerateMock<ICustomerHandler>());
        var result = manager.CreateCustomerRelations();
        Assert.AreEqual(1, result.HappyCustomers);
        Assert.AreEqual(0, result.UnhappyCustomers);
    }  
