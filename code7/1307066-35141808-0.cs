    [SetUpFixture]
    public static class MySetUpFixture
    {
        [OneTimeSetUp]
        public static void SetUpTestEnvironment()
        {
            // Set up the environment, possibly leaving information
            // for the tests to use in static fields or properties.
        }
        [OneTimeTearDown]
        public static void CleanUpEnvironment()
        {
            // If any cleanup is needed, do it here
        }
    }
