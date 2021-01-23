    public class MyTestMethodAttribute : TestMethodAttribute
    {
        public override TestResult[] Execute(ITestMethod testMethod)
        {
            TestResult[] testResults = base.Execute(testMethod);
            foreach (var testResult in testResults.Where(e => e.Outcome == UnitTestOutcome.Failed))
                testResult.LogOutput += $"Exception `{testResult.TestFailureException.GetType().Name}` with message `{testResult.TestFailureException.Message}`.";
            return testResults;
        }
    }
