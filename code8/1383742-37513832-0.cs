            public TestContext TestContext { get; set; }
           [TestCleanup]
            public void CleanupTest()
            {
                Console.WriteLine(
                    "TextContext.TestName='{0}' {1} ",
                    TestContext.TestName,
    (Microsoft.VisualStudio.TestTools.UnitTesting.UnitTestOutcome.Passed==TestContext.CurrentTestOutcome?"Pass":"Fail"));
            }
