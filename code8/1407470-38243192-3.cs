    //Arrange
    var service = Mock.Of<IService>();
    var outerService = new OuterService(service);
    var testObject = new TestObject { Name = "testObject" };
    
    //Act
    outerService.Notify(testObject);
    //Assert
    Mock.Get(service).Verify(s => s.SendNotification(It.IsAny<String>(), It.IsAny<TestObject>(), null), Times.Once);
