    public class Record
    {
        public string status { get; set; }
        public int version { get; set; }
        public Dictionary<string, string> form_values { get; set; }
    }
    
    public class Data
    {
        public List<Record> records { get; set; }
        public int current_page { get; set; }
        public int total_pages { get; set; }
        public int total_count { get; set; }
        public int per_page { get; set; }
    }
