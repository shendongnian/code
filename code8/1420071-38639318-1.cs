    var owinMock = new Mock<IOwinContext>();
    var userStoreMock = new Mock<IUserStore<ApplicationUser>>();
    userStoreMock.Setup(s => s.FindByIdAsync("testId")).ReturnsAsync(new ApplicationUser
    {
        Id = "testId",
        Email = "test@email.com"
    });
    var applicationUserManager = new ApplicationUserManager(userStoreMock.Object);
    owinMock.Setup(o => o.Get<ApplicationUserManager>(It.IsAny<string>())).Returns(applicationUserManager);
    ta.Request.SetOwinContext(owinMock.Object);
