    [TestMethod]
    public void Account_Controller_Should_Signin() {
        //Arrange
        var mock = new Mock<IInterimIdentityProvider>();
        mock.Setup(m => m.InterimIdentifier).Returns("My identifier string");
        var controller = new AccountController(mock.Object);
        var model = new LoginViewModel() {
            Username = "TestUser",
            Password = ""TestPassword
        };
        //Act
        var actionResult = controller.Signin(model);
        //Assert
        //...assert your expected results
    }
