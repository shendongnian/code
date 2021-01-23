    [TestClass]
    public class AdminNotesControllerTests
    {
        [TestMethod]
        public void CreateAction_ModelStateIsValid_EnsureRedirectToActionContainsExpectedRoutes()
        {
            // Arrange
            var fakeNote = new AdminNote();
            var stubService = new Mock<IAdminNoteService>();
            var sut = new AdminsNotesController(stubService.Object);
            
            var fakeHttpContext = new Mock<HttpContextBase>();
            var fakeIdentity = new GenericIdentity("User");
            var principal = new GenericPrincipal(fakeIdentity, null);
            fakeHttpContext.Setup(t => t.User).Returns(principal);
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.Setup(t => t.HttpContext)
            .Returns(fakeHttpContext.Object);
            sut.ControllerContext = controllerContext.Object;
            sut.FakeDateTimeDelegate = () => new DateTime(2015, 01, 01);
            // Act
            var result = sut.Create(fakeNote) as RedirectToRouteResult;
            // Assert
            Assert.AreEqual(result.RouteValues["controller"], "Admin");
            Assert.AreEqual(result.RouteValues["action"], "UserDetails");
        }       
    }
	
	
