    [TestClass]
    public class MyUserDependentControllerTest {
        [TestMethod]
        public void CanDoDetails() {
            //Arrange
            string[] roles = new[] { "Admin", "SuperUser" };
            var u = new Mock<IMyUser>();
            u.Setup(x => x.Name).Returns("username@test.io");
            u.Setup(x => x.Id).Returns(1);
            u.Setup(x => x.CompanyId).Returns(99).Verifiable();
            var mockUser = u.Object;
            var controller = new MyController() {
                //... repositories....
                MyUser = mockUser
            };
            controller.ControllerContext = new ControllerContext() {
                Controller = controller,
                RequestContext = new RequestContext(new MockHttpContext(mockUser, roles), new RouteData())
            };
            //Act
            var result = controller.Details(1, 2);
            //Assert
            var viewResult = result as ViewResult;
            Assert.IsNotNull(viewResult);
            var model = viewResult.Model as MyModel;
            Assert.IsNotNull(model);
            u.Verify();
        }
        public class MyController : Controller {
            public ActionResult Details(int? subsidId = null, int? req = null) {
                //...
                var user = this.User.GetInfo();
                //
                populateCombos(subsidId, user.CompanyId, req);
                //this is just for matching test expectations
                var model = new MyModel();
                return View(model);
            }
            private void populateCombos(int? subsidId, int? nullable, int? req) {
                //Empty as I have no clue what happens in here
            }
            public IMyUser MyUser { get; set; }
        }
        public class MyModel { }
    }
