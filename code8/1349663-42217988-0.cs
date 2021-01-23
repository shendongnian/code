    [TestClass]
    public static class TestSettings
    {
        public static bool SessionTestsFailed = false;
        [AssemblyInitialize]
        public static void runsBeforeAnyTest(TestContext t)
        {
            TestSettings.SessionTestsFailed = false;
        }
    }
    [TestClass]
    public class Tests1
    {
        public TestContext TestContext { get; set; }
        [TestInitialize()]
        public void MyTestInitialize()
        {
            if (TestSettings.SessionTestsFailed)
                Assert.Fail("Session failed, test aborted");
        }
        [TestCleanup]
        public void MyTestFinalize()
        {
            if (TestContext.CurrentTestOutcome != UnitTestOutcome.Passed)
                TestSettings.SessionTestsFailed = true;
        }
        [TestMethod]
        public void test11()
        {
            Console.WriteLine("test11 ran");
            Assert.Fail("fail the test");
        }
        [TestMethod]
        public void test12()
        {
            Console.WriteLine("test12 ran");
            Assert.Fail("fail the test");
        }
    }
    [TestClass]
    public class Tests2
    {
        public TestContext TestContext { get; set; }
        [TestInitialize()]
        public void MyTestInitialize()
        {
            if (TestSettings.SessionTestsFailed)
                Assert.Fail("Session failed, test aborted");
        }
        [TestCleanup]
        public void MyTestFinalize()
        {
            if (TestContext.CurrentTestOutcome != UnitTestOutcome.Passed)
                TestSettings.SessionTestsFailed = true;
        }
        [TestMethod]
        public void test21()
        {
            Console.WriteLine("test21 ran");
            Assert.Fail("fail the test");
        }
        [TestMethod]
        public void test22()
        {
            Console.WriteLine("test22 ran");
            Assert.Fail("fail the test");
        }
