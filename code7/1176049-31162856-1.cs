    using System;
    using NUnit.Framework;
    
    namespace Test.TestUI
    {
        [TestFixture(BaseTestFixture.BrowserType.Chrome)]
        [TestFixture(BaseTestFixture.BrowserType.Firefox)]
        [TestFixture(BaseTestFixture.BrowserType.InternetExplorer)]
        public class DemoTest : WebDriverFactory
        {
            public DemoTest(BaseTestFixture.BrowserType browser)
                : base(browser)
            {
                
            }
    
            [TestFixtureSetUp]
            public void SetUpEnvironment()
            {
                
            }
        }
    }
