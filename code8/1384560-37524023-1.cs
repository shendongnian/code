    var mockService = new Mock<IMyDataService>();
    mockService.Setup(mock => mock.ProcessFilter(null));
    ViewModel vm = new ViewModel(mockService.Object);
    Dictionary<string,string> filters = null;
    // Act
    vm.ProcessFilters(filters);
    // Assert
    mockService.Verify(x=>x.ProcessFilters(filters), Times.Once);
