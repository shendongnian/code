    [TestMethod]
    public void GetBOUser_WithExistingUser_ReturnsUser()
    {
        // Arrange
        var name = "Joe";
        var domain = "extranet";
        var fullName = name + @"\" + domain;
        var principal = new Mock<IPrincipal>();
        principal.Setup(p => p.Identity.Name).Returns(fullName);
        var joeUser = User.FromPrincipal(principal);
        var userService = new Mock<IUserService>();
        userService.Setup(u => u.Exists(fullName)).Returns(true);
        userService.Setup(u => u.FromName(fullName)).Returns(joeUser.Object);
        var controller = new ApiController(userService.Object);
        // Act
        var result = controller.GetBOUser("extranet", "Joe", "password", new Login());
        // Assert
        Assert.AreEqual(fullName, result.Name);
    }
