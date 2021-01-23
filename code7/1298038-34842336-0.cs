    public class SettingGroup
    {
        [JsonMergeKey]
        public string name { get; set; }
        // Remainder unchanged
    }
    public class Setting
    {
        [JsonMergeKey]
        public string name { get; set; }
        // Remainder unchanged
    }
