    [TestClass]
    public class MyControllerTests {
        public class FakeController : MyController { 
            public FakeController(ITestService service) : base(service) { }
        }
    
        [TestMethod]
        public void TestMyController() {
            //Arrange
            var mockService = new Mock<ITestService>();
            mockService
                .Setup(m => m.ChangePassword(....))
                .ReturnsAsync(....);
            var controller = new FakeController(mockService.Object);
        
            //Set a fake request. If your controller creates responses you will need this
            controller.Request = new HttpRequestMessage {
                RequestUri = new Uri("http://localhost/api/my")
            };
            controller.Configuration = new HttpConfiguration();
            controller.User = GetPrincipal();
        
            //Act
            var result = await controller.ChangePassword("NewPassword", "OldPassword");
        
            //Assert
            //...
        }
    }
