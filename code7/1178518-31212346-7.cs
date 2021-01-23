    public class Base
    {
        public Base(ITestOutputHelper testOutputHelper)
        {
            var helper = (TestOutputHelper)testOutputHelper;
            ITest test = (ITest)helper.GetType().GetField("test", BindingFlags.NonPublic | BindingFlags.Instance)
                                      .GetValue(helper);
            testOutputHelper.WriteLine("Test method name is " + test.TestCase.TestMethod.Method.Name);
        }
    }
