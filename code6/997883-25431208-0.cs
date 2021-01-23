    [TestFixture]
    public class UserRepositoryIntegrationTests : AIntegrationTests
    {
        private UserRepository _sut;
    
        [SetUp]
        public void SetUp()
        {
            _sut = new UserRepository();
            base.SetUp();
        }
    
        //tests
    }
