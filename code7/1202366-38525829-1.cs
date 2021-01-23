    [TestFixture()]
        public class TestClass
        {
           
            [TestFixtureSetUp]
            public void Init()
            {
                Driver.initialize(new InternetExplorerDriver());
            }
            [TearDown]
           public void Close()
            {
