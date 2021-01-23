    //arrange
    mockZincContainer
        .Setup(container => container.Resolve<ISomeInterface>())
        .Returns(new ConcreteClassThatDerivesFromSomeInterface());
    var testClass = new ClassToBeTested(mockZincContainer.Object);
    //act
    testClass.DoYourMethod();
    //assert
    mockZincContainer.Verify(c => c.Resolve<ISomeInterface>(), Times.Once);
