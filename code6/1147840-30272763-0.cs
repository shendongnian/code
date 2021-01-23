    [Test]
    public void TetMethod()
    {
        //Setup
        var cacheProveder = new Mock<ICacheProveder>();
        cacheProveder.Setup(a => a.GetOrAddToCache<string>(It.IsAny<string>(), It.IsAny<Func<string>>()))
                        .Returns((string key, Func<string> populateFunc) => { return populateFunc(); });
        // rest of the code
    }
