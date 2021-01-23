    //Arrange
    var fixture = new Fixture();
    fixture.Customize(new Ploeh.AutoFixture.AutoMoq.AutoMoqCustomization());
    var service = fixture.Freeze<IService>();
    var outerService = fixture.Create<OuterService>();
    var testObject = fixture.Create<TestObject>();
    //Act
    outerService.Notify(testObject);
    //Assert
    Mock.Get(service).Verify(s => s.SendNotification(It.IsAny<String>(), It.IsAny<TestObject>(), null), Times.Once);
