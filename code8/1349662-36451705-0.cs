    [TestClass]
    public class BaseTest
    {
        private static bool _failAllTests;
        public TestContext TestContext { get; set; }
        [TestInitialize]
        public void InitializeMethod()
        {
            if (_failAllTests)
            {
                Assert.Fail("Fail all tests");
            }
        }
        [TestCleanup]
        public void CleanUpMethod()
        {
            if (TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
            {
                _failAllTests = true;
            }
        }
    }
    [TestClass]
    public class UnitTest1 : BaseTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.Fail("TestMethod1 failed!");
        }
        [TestMethod]
        public void TestMethod2()
        {
            Assert.IsTrue(true, "TestMethod2 passed!");
        }
    }
