    public class ClassTest
    {
        [Test]
        [OnFailure] // << your custom attribute here
        public void MyTest()
        {
            Assert.Fail("test failed");
        }
    }
    [AttributeUsage(AttributeTargets.Method)]
    public class OnFailureAttribute : TestActionAttribute
    {
        public override void AfterTest(TestDetails testDetails)
        {
            if(TestContext.CurrentContext.Result.Status == TestStatus.Failed)
            {
                // TODO: your error handling
                Console.WriteLine(testDetails.FullName + " failed");
            }
        }
    }
