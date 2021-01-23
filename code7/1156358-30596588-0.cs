    [TestMethod]
    public void Can_Mock_Sales_Force_Repo()
    {
    	// arrange
    	var salesForcePolicyRepo = MockRepository.GenerateMock<IRepository<SalesForcePolicy>>();
    
    	// act
    	var clientId = decimal.Parse("123456");
    	var salesForcePolicy = new SalesForcePolicy { PolicyNumber = "123456" };
    	IEnumerable<SalesForcePolicy> salesForcePolicies = new List<SalesForcePolicy> { salesForcePolicy };
    	salesForcePolicyRepo.Stub(x => x.FindByExp(null)).IgnoreArguments().Return(salesForcePolicies.AsQueryable());
    	var policy = salesForcePolicyRepo.FindByExp(x => x.IdNumber == clientId).FirstOrDefault();
    	
    	// assert
    	Assert.IsTrue(policy == salesForcePolicy);
    }
