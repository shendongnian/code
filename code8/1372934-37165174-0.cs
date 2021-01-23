    public static ICacheService GetMockCacheService<T>() where T : class
    {
         var mock = new Mock<ICacheService>();
         mock.Setup(service => service.GetOrSet(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<Func<T>>()))
             .Returns(default(T));
         return mock.Object;
    }
