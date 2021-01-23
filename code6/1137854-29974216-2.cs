    public class WordStats
    {
        public string Word { get; set; }
        public int Count { get; set; }
        public List<int> AppearsInLines { get; set; }
        public Word()
        {
            AppearsInLines = new List<int>();
        }
    }
