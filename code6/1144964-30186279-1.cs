    [TestFixture]
    public class HomeControllerTest
    {
        Mock<IMapContext> _mapContext;
        [SetUp]
        public void SetUp()
        {
            _mapContext = new Mock<IMapContext>();
        }
        [Test]
        public void BasicTest()
        {
            HttpConfiguration configuration = new HttpConfiguration();
            HttpRequestMessage request = new HttpRequestMessage();
            var homeController = new HomeController(_mapContext.Object);
            homeController.Request = request;
            
            var result = homeController.Index();
            Assert.IsNotNull(result);
            Assert.AreEqual(<somevalue>, result.SomeProperty);
         }
    }
