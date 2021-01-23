    [TestClass]
    public class Initialize
    {
        [AssemblyInitialize]
        public static void InitializeLogging(TestContext testContext)
        {
             AppDomain.CurrentDomain.FirstChanceException += 
                               (object source, FirstChanceExceptionEventArgs e) =>
             {
                LogManager.GetLogger("TestExceptions").Error(e.Exception);
             };
        }
    }
