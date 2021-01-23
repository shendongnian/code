    [CheckForJSErrors] // your custom attribute - applies to all tests
    public class ClassTest
    {
        [Test]
        public void MyTest()
        {
            // Your test case
        }
    }
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class CheckForJSErrorsAttribute : TestActionAttribute
    {
        public override void AfterTest(TestDetails testDetails)
        {
            // if you only want to check for JS errors if the test passed, then:
            if(TestContext.CurrentContext.Result.Status == TestStatus.Passed)
            {
                Driver.TakeScreenshot(testDetails.FullName, "Failed");
                Assert.Fail("Some JS error occurred"); //This is to simulate a JS error assertion
            }
        }
        public override ActionTargets Targets
        {
            // explicitly says to run this after each test, even if attr is defined on the entire test fixture
            get { return ActionTargets.Test; }
        }
    }
