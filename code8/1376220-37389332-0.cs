           public class TestBaseChrome: WebDriver
          {
            public TestContext TestContext { get; set; }
            [TestInitialize]
            public void Initialize()
            {
             //Do stuff here
            }
            [TestCleanup]
            public void Cleanup()
            {
              var testName = TestContext.TestName;
              var testResult = TestContext.CurrentTestOutcome.ToString();
          
              //Do what you need
            }
          }
