    Mock<IWrapper<basicClass>> wrapperMock = new Mock<IWrapper<basicClass>>();
    Mock<IFactory<basicClass>> factoryMock = new Mock<IFactory<basicClass>>();
    factoryMock
        .Setup(p => p.GetT(It.IsAny<string>()))
        .Returns(wrapperMock.Object);
