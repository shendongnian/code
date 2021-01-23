    public sealed class Word
    {
        public int WordID { get; set; }
        public string WordName { get; set; }
        
        public Enumerable<VoteOption> Options { get; set; }
    }
    
    public sealed class Model
    {
        public int Vote { get; set; }
        public string Option { get; set; }
    }
