    var context = new TestContext();
    var userStore = new Mock<IUserStore<ApplicationUser>>();
    //ExpectedGlobal contains a static variable call Expected_User
    //to be used as to populate the principle
    // when mocking the HttpRequestContext
    userStore
        .Setup(m => m.FindByIdAsync(ExpectedGlobal.Expected_User.Id))
        .Returns(Task.FromResult(ExpectedGlobal.Expected_User));
    var mockUserManager = new Mock<ApplicationUserManager>(userStore.Object);
    var mockUnitOfWork = 
             new Mock<IUnitOfWork>(mockUserManager.Object, context) 
             { CallBase = false };
