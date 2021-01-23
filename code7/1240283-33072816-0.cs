    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class CustomPropertyInfo : ICustomPropertyInfo
    {
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Value")]
        public string Value { get; set; }
    }
