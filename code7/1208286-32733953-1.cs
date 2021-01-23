    [TestFixture]
    public class ThreadExceptionTestFixture : BaseTestFixture
    {
        [Test, Ignore("Testing-Testing test: Enable this test to validate that exception in threads are properly caught")]
        public void ThreadExceptionTest()
        {
            var crashingThread = new Thread(CrashInAThread);
            crashingThread.Start();
            crashingThread.Join(500);
        }
        private static void CrashInAThread()
        {
            throw new Exception();
        }
        [Test, Ignore("Testing-Testing test: Enable this test to validate that exceptions in Finalizers are properly caught")]
        public void FinalizerTest()
        {
            CreateFinalizerObject();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        public void CreateFinalizerObject()
        {
            //Create the object in another function to put it out of scope and make it available for garbage collection
            new ExceptionInFinalizerObject();
        }
    }
    public class ExceptionInFinalizerObject
    {
        ~ExceptionInFinalizerObject()
        {
            throw new Exception();
        }
    }
