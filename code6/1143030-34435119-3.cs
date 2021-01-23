    [TestClass]
    public class FailingTest : TestsBase
    {
        [TestMethod]
        public void Failing()
        {
            throw new Exception("Fail");
        }
    }
