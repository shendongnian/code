    [JsonConverter(typeof(GroupingConverter))]
    class Populations 
    {
        [Group("North America")]
        public string US { get; set; }
        [Group("North America")]
        public string Canada { get; set; }
        [Group("Europe")]
        public string Germany { get; set; }
        [Group("Europe")]
        public string England { get; set; }
    }
