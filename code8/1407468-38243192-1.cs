    //Arrange
    var service = Moq.Mock.Of<IService>();
    var outerService = new OuterService(service);
    var testObject = new TestObject { Name = "testObject" };
    
    //Act
    outerService.Notify(testObject);
    //Assert
    Moq.Mock.Get(service).Verify(s => s.SendNotification(It.IsAny<String>(), It.IsAny<TestObject>(), null), Times.Once);
