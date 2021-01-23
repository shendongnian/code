    [TestClass()]
    public class MyClassthatDoesStuffTests
    {
        [TestMethod()]
        public void ImportansStuffTest()
        {
            using (ShimsContext.Create())
            {
                bool logCalled = false;
                ConsoleApplication1.Fakes.ShimMyLogger.ErrorLoggingString = 
                    (message) => logCalled = true;
                new MyClassthatDoesStuff().ImportansStuff();
                Assert.IsTrue(logCalled);
            }
        }
    }
