    [TestClass]
    public class Initialize
    {
        [AssemblyInitialize]
        public static void InitializeLogging(TestContext testContext)
        {
             AppDomain.CurrentDomain.FirstChanceException += 
                               (object source, FirstChanceExceptionEventArgs e) =>
             {
               if (e.Exception is AssertFailedException == false)
                    LogManager.GetLogger("TestExceptions").Error(e.Exception);
             };
        }
    }
