    public class BugModel
    {
        public string BugState { get; set; }
        public Dictionary<string, int> Details { get; set; }
        public int Total { get { return Details.Sum(x => x.Value); } }
    }
