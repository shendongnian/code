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
    //dont do any driver.close()
                }
             [TestMethod]
            public void TestCase001()
            {
            //your code goes here
            }
     [TestMethod]
            public void TestCase002()
            {
            //your code goes here
            }
