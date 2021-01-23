    // Create mock.
    var mockRepository = new Mock<IRepository>();
    
    // Setup to return the desired mock value. In this case, return true if any string tableId is provided.
    mockRepository.Setup(x => x.IsTableOccupied(It.IsAny<string>())).Returns(true);
    
    // Call the parent method and inject the mock.
    var testBusiness = new ExampleBusiness(mockRepository.Object);
    
    // Finally, assert that the value is as expected.
    Assert.IsTrue(testBusiness.IsTableOccupied("TestId");
