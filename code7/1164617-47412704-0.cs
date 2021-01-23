    public class RollbackAttribute : TestAttribute, ITestAction
    {
        private TransactionScope _transaction;
    
        public void BeforeTest(ITest test)
        {
            _transaction = new TransactionScope();
        }
    
        public void AfterTest(ITest test)
        {
            _transaction.Dispose();
        }
    
        public ActionTargets Targets => ActionTargets.Test;
    }
    [TestFixture]
    public class SomeTestClass
    {
        [Rollback] //No need [Test] because Rollback is inherit it.
        public void SomeTestMethod()
        {
        }
    }
