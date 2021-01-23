    [TestClass]
    public class EventSourceTests
    {
        [TestMethod]
        public void MyEventSourceShouldBeValid()
        {
            var analyzer = new EventSourceAnalyzer();
            analyzer.Inspect(MyEventSource.Log);
        }
    }
