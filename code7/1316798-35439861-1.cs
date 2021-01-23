    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class TestResultListModel : List<TestResultModel>
    {
        [JsonProperty]
        public int TotalTestCases { get { return base.Count; } }
        [JsonProperty]
        // Using Enumerable.Count() is more memory efficient than List.FindAll()
        public int TotalSuccessful { get { return this.Count(t => t.Successful); } }
        [JsonProperty]
        TestResultModel[] Items
        {
            get
            {
                return this.ToArray();
            }
            set
            {
                if (value != null)
                    this.AddRange(value);
            }
        }
    }
