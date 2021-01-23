    public class Group
    {
        [JsonConverter(typeof(AutoInterningStringConverter))]
        public string groupName { get; set; }
        public string code { get; set; }
    }
