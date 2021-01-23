    // Arrange
    var repositoryMock = new SomeMock<IPlaceInfoRepository>();
    ... // Setup mock for verification.
    var service = new Service(repositoryMock.Object);
    
    // Act
    service.FillInventory(vm);
    
    // Assert
    repositoryMock.Verify();
