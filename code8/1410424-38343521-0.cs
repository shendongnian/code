    public class Class_root
    {
        public int success { get; set; }
        public Class_d d { get; set; }
    }
    public class Class_d
    {
        public Dictionary<string, Class_scores> gameData { get; set; }
    }
    public class Class_scores
    {
        public List<scores_Entry> scores { get; set; }
        public int count { get; set; }
        public bool[] highlight { get; set; }
    }
    public class scores_Entry
    {
        public decimal max { get; set; }
        public decimal avg { get; set; }
        public int? rest { get; set; }
        public bool active { get; set; }
        public string scoreid { get; set; }
    }
