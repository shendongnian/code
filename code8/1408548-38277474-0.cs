    public class TestDetails
    {
        public string TestName { get; set; }
        public string ResultDescription { get; set; }
        public Result TestResult { get; set; }
        public string ElapsedTime { get; set; }
        public TestDetails(string testName, string resultDescription, Result result, string elapsedTime)
        {
            ResultDescription = resultDescription;
            TestResult = result;
            ElapsedTime = elapsedTime;
        }
        public enum Result
        {
            Pass,
            Fail
            // etc
        }
    }
