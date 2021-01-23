    [TestClass]
    public abstract class BaseIntegrationTest
    {
        [TestInitialize]
        public void BeforeEach() {
            // Stuff that should happen before each unit test
            BaseTestInitialize();
        }
        [TestCleanup]
        public void AfterEach(){
            // Stuff that should happen after each unit test
            BaseTestCleanup();
        }
        public virtual void BaseTestInitialize() { }
        public virtual void BaseTestCleanup() { }
    }
