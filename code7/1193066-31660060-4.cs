    var repK = new Mock<IRepositoryK>();
    // create mock and pass the same constructor parameters as actual object
    var controllerMock = new Mock<OrderController>(repK.Object);
    controllerMock.CallBase = true;
    // mock MethodB method:
    controllerMock.Setup(x => x.MethodB(It.IsAny<string>())).Returns("data");
    // call the method on mock object
    // instead of calling MethodB you will get a mocked result
    var result = controllerMock.Object.NewOrder();
