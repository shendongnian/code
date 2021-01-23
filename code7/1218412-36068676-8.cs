    [TestMethod]
    public void LoginTest() {
        //Arrange (using Moq)
        bool isAuthCookieSet = false;
        var loginmodel = new logInModel {
            Username = "arwinortiz",
            Password = "123456"
        };
        var mockAuthenticator = new Mock<IAuthenticationService>();
        var uname = It.Is<string>(s => s == loginmodel.Username);
        var pword = It.Is<string>(s => s == loginmodel.Password);
        mockAuthenticator
            .Setup(x => x.Authenticate(uname, pword))
            .Returns(true);
        var mockFormsAuthentication = new Mock<IFormsAuthenticationService>();
        mockFormsAuthentication
            .Setup(x => x.SetAuthCookie(uname, It.IsAny<bool>()))
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
