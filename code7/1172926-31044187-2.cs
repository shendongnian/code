    public class HighlightInfo2
    {
        private Dictionary<string, List<JsonArray>> _content;
        public string _id { get; set; }
        public string _rev { get; set; }
        public Dictionary<string, List<JsonArray>> content
        {
            get { return _content; }
            set
            {
                _content = value;
                foreach (var item in _content)
                {
                    contentJson += string.Join("\r\n", item.Value);
                }
            }
        }
         [JsonIgnore] //note, this depends on your json serializer
        public string contentJson { set; get; }
        public long created { get; set; }
    }
