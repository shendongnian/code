    public class HighlightInfo2
    {
        public string _id { get; set; }
        public string _rev { get; set; }
        public long created { get; set; }
        private JToken _content { get; set; }
        public JToken content
        {
            get { return _content; }
            set
            {
                _content = value;
                contentString = JsonConvert.SerializeObject(value);
            }
        }
        [JsonIgnore]
        public string contentString { get; set; }
    }
