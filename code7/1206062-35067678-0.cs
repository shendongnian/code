    public class QueryBuilderSettings
    {
        public List<Filter> filters { get; set; }
        public bool allow_empty { get; set; }
        public int allow_groups { get; set; }
    }
    
    public class Filter
    {
        public string id { get; set; }
        public string label { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public FilterType? type { get; set; }
        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        public List<FilterOperators> operators { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public InputType? input { get; set; }
        public List<object> values { get; set; }
    }
    public enum FilterType
    {
        @string, 
        @integer, 
        @double, 
        @date, 
        @time, 
        @datetime,
        @boolean
    }
    public enum FilterOperators
    {
        equal,
        not_equal,
        @in,
        not_in,
        less,
        less_or_equal,
        greater,
        greater_or_equal,
        between,
        not_between,
        begins_with,
        not_begins_with,
        contains,
        not_contains,
        ends_with,
        not_ends_with,
        is_empty,
        is_not_empty,
        is_null,
        is_not_null
    }
    public enum InputType
    {
        text,
        textarea,
        radio,
        checkbox,
        select
    }
