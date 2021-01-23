    public class AIntegrationTests
    {
    
        protected TransactionScope transaction = null;
    
        [SetUp]
        public virtual void SetUp()
        {
            transaction = new TransactionScope(TransactionScopeOption.Required);
        }
    
        [TearDown]
        public void TearDown()
        {
            transaction.Dispose();
        }
    
    }
    
    [TestFixture]
    public class UserRepositoryIntegrationTests : AIntegrationTests
    {
        private UserRepository _sut;
    
        [SetUp]
        public override void SetUp()
        {
            _sut = new UserRepository();
            base.SetUp();
        }
    
        //tests
    }
