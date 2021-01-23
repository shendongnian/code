    Mock<IRepositoryK> repK = new Mock<IRepositoryK>();
    Mock<IGoogleClient> googleClient = new Mock<IGoogleClient>();
    repK.Setup(x => x.MethodA(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns("Yippe");
    googleClient.Setup(It.IsAny<string>()).Returns("something");
    var controller = new OrderController(repK.Object, googleClient.Object);
    // Test what you want on controller object
