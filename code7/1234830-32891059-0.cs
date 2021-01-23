        [TestClass]
        public class UserControllerTests
        {
           [TestMethod]
           public async Task UserController_GetAll_Returns_Not_Null()
           {
              var result = await controller.GetALL();
              Assert.IsNotNull(result);
           }
       }
