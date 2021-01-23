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
    public void TestCache()
    {
        var sut = GetSystemUnderTest();
        sut.SetCache("key", "value"); //NULL Reference thrown here
    }
    
