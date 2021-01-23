    [SetUpFixture]
    public class PreFixture
    {
        [OneTimeSetUp]
        public void SetUp() {
            Directory.SetCurrentDirectory(TestContext.CurrentContext.TestDirectory);
        }
    }
