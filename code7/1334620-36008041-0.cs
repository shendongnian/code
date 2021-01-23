    public static class RunUnitTestsClass<TUnitTests> where TUnitTests : new()
    {
        private static IEnumerable<MethodInfo> WithAttribute<TAttribute>()
        {
            return typeof(TUnitTests).GetMethods().Where(method => method.GetCustomAttributes(typeof(TAttribute), true).Any());
        }
        private static void RunWithAttribute<TAttribute>()
        {
            var unitTests = new TUnitTests();
            foreach (var method in WithAttribute<TAttribute>())
                method.Invoke(unitTests, new object[0]);
        }
        public static void RunTestFixtureSetup()
        {
            RunWithAttribute<TestFixtureSetUp>();
        }
        // same for the rest of them
        public static void RunTests(TestConfiguration tConf)
        {
            var unitTests = new TUnitTests();
            foreach (var method in WithAttribute<Test>())
                method.Invoke(unitTests, new []{tConf});
        }
    }
