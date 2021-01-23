       [TestClass]
        public class TestDemo : BaseTests
        {
            [TestMethod]
            public void SaveOrder_OnlyRequiredValuesFilled_SuccessfullySaved()
            {
                //Run some SQL queries 
            }
    
        }
    
        [TestClass]
        public abstract class BaseTests
        {
            [TestInitialize]
            public void Setup()
            {
                Console.WriteLine("Setup executed.");
                //begin transaction
            }
    
            [TestCleanup]
            public void Cleanup()
            {
                Console.WriteLine("Cleanup executed.");
                //rollback transaction
            }
        }
