    [Fact]
    public void TestCache()
    {
        //Arrange
        var mockCache = new Mock<IMemoryCache>();
            
        sut = new Test(mockCache.Object);
    
        //Act
        sut.SetCache("key", "value");
    
        //Assert
        mockCache.Verify(m => m.Set(It.Any<string>(),It.Any<string>(),It.Any<MemoryCacheEntryOptions>(), Times.AtLeastOnce());//verifies that method was called matching provided setup
    }
