    public class ComputerData
    {
        [JsonProperty("Computer ID")]
        public string ComputerID { get; set; }
        [JsonProperty("Application Name")]
        public string ApplicationName { get; set; }
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? Date { get; set; }
        public int Count { get; set; }
    }
