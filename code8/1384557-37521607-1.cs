    [TestMethod]
    public void ProcessFilters_Test()
    {
        // Arrange.
        var mock = new Mock<IMyDataService>();
        var vm = new ViewModel(mock.Object);
        // Act.
        vm.ProcessFilters();
        // Assert.
        mock.Verify(s => s.ProcessFilters(null), Times.Once);
    }
