    public class FormValues
    {
        [JsonProperty(PropertyName = "4015")]
        public string T4015 { get; set; }
        [JsonProperty(PropertyName = "5919")]
        public string T5919 { get; set; }
        [JsonProperty(PropertyName = "6127")]
        public string T6127 { get; set; }
        [JsonProperty(PropertyName = "7868")]
        public string T7868 { get; set; }
        public string q311 { get; set; }
        public string r83b { get; set; }
    }
    
    public class Record
    {
        public string status { get; set; }
        public int version { get; set; }
        public FormValues form_values { get; set; }
    }
    
    public class Data
    {
        public List<Record> records { get; set; }
        public int current_page { get; set; }
        public int total_pages { get; set; }
        public int total_count { get; set; }
        public int per_page { get; set; }
    }
