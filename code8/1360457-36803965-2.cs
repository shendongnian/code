    [TestClass]
    public class HomeControllerTests
    {
        /// <summary>
        /// Tests the Edit method is run
        /// </summary>
        [TestMethod]
        public void Edit_Method_Is_Run()
        {
            //Arrange
            var mockRepository = new Mock<IEditDataRepository>();
            mockRepository
                 .Setup(x => x.Edit(It.IsAny<FormViewModel>()));
            HomeController controller = new HomeController(mockRepository.Object);
            //Act
            controller.Edit(It.IsAny<FormViewModel>());
            //Assert
            mockRepository.VerifyAll();
        }
        [TestMethod]
        public void Edit_Returns_OK()
        {
            //Arrange
            var mockRepository = new Mock<IEditDataRepository>();
            mockRepository
                 .Setup(x => x.Edit(It.IsAny<FormViewModel>()));
            HomeController controller = new HomeController(mockRepository.Object);
            //Act            
            var response = controller.Edit(It.IsAny<FormViewModel>());
            //Assert
            Assert.IsInstanceOfType(response, typeof(HttpStatusCodeResult));
            var httpResult = response as HttpStatusCodeResult;
            Assert.AreEqual(200, httpResult.StatusCode);
        }
        /// <summary>
        /// Tests the Edit method throws exception
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(HttpResponseException))]
        public void Edit_Returns_Exception()
        {
            var mockRepository = new Mock<IEditDataRepository>();
            mockRepository
                .Setup(x => x.Edit(It.IsAny<FormViewModel>()))
                .Throws(new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest)));
            HomeController controller = new HomeController(mockRepository.Object);
            //Act            
            var response = controller.Edit(It.IsAny<FormViewModel>());
            //Assert
            Assert.IsInstanceOfType(response, typeof(HttpResponseException));
        }
    }
