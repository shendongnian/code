    var owinMock = new Mock<IOwinContext>();
    var userStoreMock = new Mock<IUserStore<ApplicationUser>>();
    var applicationUserManager = new ApplicationUserManager(userStoreMock.Object);
    owinMock.Setup(o => o.Get<ApplicationUserManager>(It.IsAny<string>())).Returns(applicationUserManager);
    ta.Request.SetOwinContext(owinMock.Object);
