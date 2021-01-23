    class OriginalNameContractResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            // Get the JsonProperties (with annotated names) from the base class
            IList<JsonProperty> list = base.CreateProperties(type, memberSerialization);
            // For each property, replace the annotated name with the real name
            foreach (JsonProperty prop in list)
            {
                prop.PropertyName = prop.UnderlyingName;
            }
            return list;
        }
    }
