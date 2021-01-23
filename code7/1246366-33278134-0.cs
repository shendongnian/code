    using Moq;
    [TestFixture]
    public class AdminControllerTest
    {
        [Test]
        public void Edit()
        {
            var mockSession = new Mock<HttpSessionStateBase>();
            mockSession.Setup(f => f["admin"]).Returns(()=> "yesToAdmin");
            var mockContext = new Mock<HttpContextBase>();
            mockContext.Setup(f => f.Session).Returns(mockSession.Object);
            AdminController admin = new AdminController();
            admin.ControllerContext = new ControllerContext()
            {
                Controller = admin,
                RequestContext = new RequestContext(mockContext.Object, new RouteData())
            };
            var id = admin.Edit(3) as ViewResult;
            Assert.AreEqual("Edit", id.ViewName);
        }
    }
