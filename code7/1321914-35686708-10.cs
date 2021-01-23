        [TestClass]
        public class HomePageTests
        {
      
            public TestContext TestContext { get; set; }
            [ClassInitialize]
            public static void Initialize(TestContext context)
            {
                if (Utils.driver != null)
                    Utils.driver.Quit();
                Utils.driver = TestUtils.GetDriver();
                Utils.driver.Manage().Window.Maximize();
            }
        }
  
