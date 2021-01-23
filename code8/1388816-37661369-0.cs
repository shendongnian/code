        public Tests(Platform platform)
        {
            this.platform = platform;
        }
        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }
