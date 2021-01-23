    [TestClass]
    public class DemoControllerTests {
        [TestMethod]
        public async Task CreateFromDraftShouldSucceed() {
            // This version uses a mock UrlHelper.
            // Arrange
            var controller = new DemoController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            string locationUrl = "http://localhost/api/demo/1";
            // Create the mock and set up the Link method, which is used to create the Location header.
            // The mock version returns a fixed string.
            var mockUrlHelper = new Mock<UrlHelper>();
            mockUrlHelper.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns(locationUrl);
            controller.Url = mockUrlHelper.Object;
            // Act
            var request = "Hello World";
            var result = await controller.DemoRequestPost(request);
            var response = await result.ExecuteAsync(System.Threading.CancellationToken.None);
            // Assert
            Assert.AreEqual(locationUrl, response.Headers.Location.AbsoluteUri);
        }
    }
