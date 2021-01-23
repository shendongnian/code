    [TestFixture(Platform.Android)]
    public class Tests
    {
        IApp app;
        Platform platform;
        public Tests(Platform platform)
        {
            this.platform = platform;
        }
        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }
        [Test]
        public void AppLaunches()
        {
            app.Repl();
        }
    }
