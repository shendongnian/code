    [TestClass]
    public class HomeControllerTests {
        [TestInitialize]
        public void Init() {
            MappingConfig.RegisterMaps();
        }
    
        [TestMethod]
        public void ItemsListing() {
            HomeController controller = new HomeController();
    
            ViewResult result = controller.ItemsListing() as ViewResult;
    
            Assert.IsNotNull(result);
        }
    }
