    [MyRule] // your custom attribute - applied to all tests
    public class ClassTest
    {
        [Test]
        public void MyTest()
        {
            // ...
        }
    }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class MyRuleAttribute : TestActionAttribute
    {
        public override void BeforeTest(TestDetails testDetails)
        {
            // connect
        }
        public override void AfterTest(TestDetails testDetails)
        {
            // disconnect
        }
    }
