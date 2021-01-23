    class IgnoreJsonAttributesResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> props = base.CreateProperties(type, memberSerialization);
            foreach (var prop in props)
            {
                prop.Ignored = false;   // Ignore [JsonIgnore]
                prop.Converter = null;  // Ignore [JsonConverter]
            }
            return props;
        }
    }
