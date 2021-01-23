    [TestClass]
    public static class GlobalSetup
    {
        [AssemblyInitialize]
        public static void Setup(TestContext context)
        {
            AppDomain.CurrentDomain.FirstChanceException += (s, e) => LastException = e.Exception;
        }
    
        public static Exception LastException { get; private set; }
    }
