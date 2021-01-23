    [TestFixture]
        [Category("MyTestSet")]
        public class MyTests
        {
            [Test, TestCaseSource(nameof(GetTestParameters))]
            public void TestCase(int parameter)
            {
                ExecuteTestCase(parameter);
            }
            static int[] GetTestParameters()
            {
                //call web service and get parameters
                return new[] { 1, 2, 3 };
            }
        }
