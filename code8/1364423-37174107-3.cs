    [TestClass]
    public class RouteTableUnitTests : ControllerUnitTests {
        [TestMethod]
        public void Should_Get_Request_From_Route_Table() {
            //Arrange
            var contextBase = HttpContext.Current.Request.RequestContext.HttpContext;
            var routes = RouteTable.Routes;                
            var sut = new RouteInspector(routes, contextBase);
            //Act
            var actual = sut.RequestIsInRoutes();
            //Assert
            Assert.IsTrue(actual);
        }
    }
