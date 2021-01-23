    mockCache.Setup(c => c.Get(It.Is<string>(x))).Returns(y);
    
    //...other code
    mockCache.Object.Set(x, z);
    mockCache.Setup(c => c.Get(It.Is<string>(x)).Returns(z);
    //...other code
