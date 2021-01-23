    public class RootObject
    {
        [JsonProperty(PropertyName = "snippets")]
        public MarkLogicSnippetsModel Snippets { get; set; }
    }
    public class MarkLogicSnippetsModel
    {
        [JsonProperty(PropertyName = "match")]
        public IEnumerable<MarkLogicMatchModel> Matches { get; set; }
    }
    public class MarkLogicMatchModel
    {
        [JsonProperty(PropertyName = "value")]
        public List<MarkLogicMatchEntry> Values { get; set; }
    }
    public enum MatchType
    {
        Normal,
        Highlight,
    }
    [JsonConverter(typeof(MarkLogicMatchEntryConverter))]
    public class MarkLogicMatchEntry
    {
        public MatchType MatchType { get; set; }
        public string Value { get; set; }
    }
