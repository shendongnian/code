    [TestFixture]
    public abstract class BaseTestClass
    {
        private Stopwatch _stopWatch;
    
        [SetUp]
        public void Init()
        {
            _stopWatch = Stopwatch.StartNew();   
        }
    
        [TearDown]
        public void Cleanup()
        {
            Debug.WriteLine("Excution time for {0} - {1} ms",
            _stopWatch.Stop();
            TestContext.CurrentContext.Test.Name,
            _stopWatch.ElapsedMilliseconds);
            // ... add your code here
        }
    }
