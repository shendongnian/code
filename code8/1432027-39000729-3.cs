    [TestClass]
    public class HomeControllerTests {
        [ClassInitialize]
        public static void Init(TestContext context) {
            MappingConfig.RegisterMaps();
        }
    
        [TestMethod]
        public void ItemsListing() {
            HomeController controller = new HomeController();
    
            ViewResult result = controller.ItemsListing() as ViewResult;
    
            Assert.IsNotNull(result);
        }
    }
