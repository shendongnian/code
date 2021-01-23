    [Test]
    public async Task GetReturns200IfSuccessful()
    {
        //Arrange
        //Act
        var response = await _sut.GetAsync();
        //Assert
        response.Should().BeOfType<OkNegotiatedContentResult<string>();
    }
