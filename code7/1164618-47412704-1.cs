    public class RollbackTestBase
    {
        private TransactionScope _transaction;
    
        [TestInitialize]
        public virtual void Setup()
        {
            _transaction = new TransactionScope();
        }
    
    
        [TestCleanup]
        public virtual void TearDown()
        {
            _transaction.Dispose();
        }
    }
    
    [TestClass]
    public class IntegrationTest : RollbackTestBase
    {
        [TestMethod]
        public void TestDataBase()
        {
            Assert.IsTrue(true);
        }
            
        [TestInitialize]
        public virtual void Init()
        {
        }
    
        [TestCleanup]
        public virtual void CleanUp()
        {
        }
    }
