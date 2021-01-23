    [TestClass]
    public class Tests
    {
        [TestInitialize]
        public void Initialize()
        {
            Console.WriteLine("initialize");
        }
        [TestCleanup]
        public void Cleanup()
        {
            Console.WriteLine("cleanup");
        }
        [TestMethod]
        public void Test()
        {
            Console.WriteLine("test body");
        }
    }
