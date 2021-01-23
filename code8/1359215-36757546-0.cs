    public class BaseSetup
    {
            protected const string CategoryToExclude = "Write";
    
            [SetUp]
            public void Init()
            {  
                string env =  ConfigurationManager.GetEnvironment();
                if ( env == Constants.Environments.PROD && (TestContext.CurrentContext.Test.Properties["Categories"].Contains(CategoryToExclude)))
                {
                    Assert.Inconclusive(String.Format("Cannot run this test on environment: {0}", env));
                }
            }
        }
    
        [TestFixture]
        public class UnitTests : BaseSetup
        {
            [Test]
            [Category(CategoryToExclude)]
            public void TestMethod1()
            {
                Console.WriteLine("TestMethod1");
            }
    
            [Test]
            public void TestMethod2()
            {
                Console.WriteLine("TestMethod2");  
            }
        }
