    [TestClass()]
    public class MyClassthatDoesStuffTests
    {
        [TestMethod()]
        public void ImportansStuffTest()
        {
            using (ShimsContext.Create())
            {
                bool logCalled = false;
                ConsoleApplication1.Fakes.ShimmyLogger.ErrorLoggingString = 
                    (message) => logCalled = true;
                new myClassthatDoesStuff().ImportansStuff();
                Assert.IsTrue(logCalled);
            }
        }
    }
