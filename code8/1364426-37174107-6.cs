    [TestClass]
    public class RouteTableUnitTests : ControllerUnitTests {
        [TestMethod]
        public void Should_Get_Request_From_Route_Table() {
            //Arrange                
            var contextBase = new Mock<IHttpContextAccessor>();
            contextBase.Setup(m => m.HttpContext)
                .Returns(HttpContext.Current.Request.RequestContext.HttpContext);
            var routeTable = new Mock<IRouteTable>();
            routeTable.Setup(m => m.Routes).Returns(RouteTable.Routes);
            var sut = new RouteInspector(routeTable.Object, contextBase.Object);
            //Act
            var actual = sut.RequestIsInRoutes();
            //Assert
            Assert.IsTrue(actual);
        }
    }
