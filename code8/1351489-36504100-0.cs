    public class SimpleClass
    {
        [JsonProperty("cid")]
        public int Id { get; set; }
        [JsonProperty("customIdentifier")]
        int CustomIdentifier
        {
            set
            {
                Id = value;
            }
        }
    }
