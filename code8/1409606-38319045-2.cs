    [Fact]
    public void TestCache()
    {
        //Arrange
        var mockCache = new Mock<IMemoryCache>();
        //Setup the mock
        mockCache.Setup(m => m.Set(It.Any<string>(),It.Any<string>(),It.Any<MemoryCacheEntryOptions>()).Verifiable();
    
        sut = new Test(mockCache.Object);
    
        //Act
        sut.SetCache("key", "value");
    
        //Assert
        mockCache.Verify();//verifies that method was called matching setup       
    }
