    [TestClass]
    public class MyControllerTests {
        internal class FakeController : MyController { }
    
        [TestMethod]
        public void TestMyController() {
            //Arrange
            var controller = new FakeController();
        
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
