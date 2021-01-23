    [SetUp]
        public void BeforeEachTest ()
        {
            app = ConfigureApp.Android.ApkFile("<path-as-string>").StartApp ();
        }
