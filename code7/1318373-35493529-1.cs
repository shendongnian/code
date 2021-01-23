    public class Character
    {
        [JsonConverter(typeof(IgnoreDictionaryTypeConverter))]
        public IDictionary<string, ISkill> Skills { get; set; }
    }
