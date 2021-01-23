    abstract class BaseTestFixture
    {
        [SetUp]
        public void SetupBeforeEachTest()
        {
            //Some code
        }
    }
    [TestFixture]
    class SomeTests : BaseTestFixure
    {
        //Tests
    }
