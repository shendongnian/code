    [Test]
    public async Task Get_ActionExecutes_ReturnsEmptyCompaniesViewModel() // async Task
    {
        var companies = new List<Company>();
        var addresses = new List<Address>();
        // Setup fake method
        _repositoryMock
            .Setup(c => c.GetCompaniesAsync())
            .ReturnsAsync(companies); // Async
        _repositoryMock
            .Setup(c => c.GetAddressesAsync())
            .ReturnsAsync(addresses); // Async
        // Execute action
        var response = await _controller.Get(); // Await
        // Check the response
        Assert.AreEqual(HttpStatusCode.PartialContent, response.StatusCode);
        _repositoryMock.Verify(m => m.GetAddressesAsync(), Times.Once);
        _repositoryMock.Verify(m => m.GetCompaniesAsync(), Times.Once);
    }
