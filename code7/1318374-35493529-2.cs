    public class Character
    {
        [JsonConverter(typeof(IgnoreDictionaryTypeConverter))]
        [JsonProperty(TypeNameHandling = TypeNameHandling.None)]
        public IDictionary<string, ISkill> Skills { get; set; }
    }
