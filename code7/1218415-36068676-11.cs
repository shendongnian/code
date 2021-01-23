    [TestMethod]
    public void LoginTest() {
        //Arrange
        var loginmodel = new logInModel {
            Username = "arwinortiz",
            Password = "123456"
        };
        var mockAuthenticator = new Mock<IAuthenticationService>();
        mockAuthenticator
                .Setup(x => x.Authenticate(It.Is<string>(s => s == loginmodel.Username), It.Is<string>(s => s == loginmodel.Password)))
                .Returns(true);
        var mockFormsAuthentication = new Mock<IFormsAuthenticationService>();
        bool isAuthCookieSet = false;
        mockFormsAuthentication
            .Setup(x => x.SetAuthCookie(It.Is<string>(s => s == loginmodel.Username), It.IsAny<bool>()))
            .Callback(() => { isAuthCookieSet = true; });
        var controller = new logInController(mockAuthenticator.Object, mockFormsAuthentication.Object);
        //Act
        var result = (System.Web.Mvc.RedirectToRouteResult)controller.Index(loginmodel);
        //Assert (using FluentAssertions)
        result.Should().NotBeNull(because: "the result should have redirected for entered user ");
        result.RouteValues["action"].ShouldBeEquivalentTo("index", because: "the redirection was to home.index action");
        result.RouteValues["controller"].ShouldBeEquivalentTo("home", because: "the result should redirect to home controller");
        isAuthCookieSet.Should().BeTrue(because: "auth cookie is set if the user was authenticated");
    }
