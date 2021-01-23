    [TestMethod]
    public void ProcessFilters_Test()
    {
        // Arrange.
        Dictionary<string,string> expectedFilters = null;
        Dictionary<string,string> actualFilters;
        var mock = new Mock<IMyDataService>();
        mock.Setup(s => ProcessFilters(It.IsAny<Dictionary<string, string>>()))
            .Callback<Dictionary<string, string>>(d => actualFilters = d);
        var vm = new ViewModel(mock.Object);
        // Act.
        vm.ProcessFilters();
        // Assert.
        mock.Verify(s => s.ProcessFilters(It.IsAny<Dictionary<string, string>>()), Times.Once);
        Assert.Equal(actualFilters, expectedFilters);
    }
