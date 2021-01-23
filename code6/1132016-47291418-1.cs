    [TestClass]
    public class UnitTestDetectorTest_WithoutIsInUnitTest
    {
        [TestMethod]
        public void IsInUnitTest_WithoutUnitTestAttribute_False()
        {
            bool expected = false;
            bool actual = UnitTestDetector.IsInUnitTest;
            Assert.AreEqual(expected, actual);
        }
    }
    [TestClass]
    public class UnitTestDetectorTest_WithIsInUnitTest
    {
        [TestInitialize()]
        public void Initialize()
        {
            UnitTestDetector.IsInUnitTest = true;
        }
        [TestCleanup()]
        public void Cleanup()
        {
            UnitTestDetector.IsInUnitTest = false;
        }
        [TestMethod]
        public void IsInUnitTest_WithUnitTestAttribute_True()
        {
            bool expected = true;
            bool actual = UnitTestDetector.IsInUnitTest;
            Assert.AreEqual(expected, actual);
        }
    }
