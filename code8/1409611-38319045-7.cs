    //...
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.DependencyInjection;
    //...
    public Test GetSystemUnderTest() {
        var services = new ServiceCollection();
        services.AddMemoryCache();
        var serviceProvider = services.BuildServiceProvider();
        
        var memoryCache = serviceProvider.GetService<IMemoryCache>();
        return new Test(memoryCache);
    }
    [Fact]
    public void TestCache() {
        //Arrange
        var sut = GetSystemUnderTest();
        //Act
        sut.SetCache("key", "value");
        //Assert
        //...
    }
    
