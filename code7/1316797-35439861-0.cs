    [JsonObject]
    public class TestResultListModel : List<TestResultModel>
    {
        public int TotalTestCases { get { return base.Count; } }
        public int TotalSuccessful { get { return base.FindAll(t => t.Successful).Count; } }
    }
