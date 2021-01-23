    [Test]
    public async Task GetReturnsValue()
    {
        //Act
        var response = await _sut.GetAsync();
        var result = response as OkNegotiatedContentResult<AssetList>;
         //Assert
         result.Should().Be("value");
    }
