    public static List<TestCase> GetAllTestCaseFromSuite(ITestPlan testPlan, int suiteId, bool includeExecutionStatus = true)
    {
        List<TestCase> testCases = new List<TestCase>();
        testPlan.Refresh();
        ITestSuiteBase currentSuite = testPlan.Project.TestSuites.Find(suiteId);
        currentSuite.Refresh();
        foreach (var currentTestCase in currentSuite.TestCases)
        {
            TestCase testCaseToAdd = new TestCase(currentTestCase.TestCase, currentSuite, testPlan, includeExecutionStatus);
            if (!testCases.Contains(testCaseToAdd))
            {
                testCases.Add(testCaseToAdd);
            }
        }
        log.InfoFormat("Load all test cases in the suite with Title= \"{0}\" id = \"{1}\"", currentSuite.Title, currentSuite.Id);
        return testCases;
    }
