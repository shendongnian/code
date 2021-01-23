    public class Dto
    {
        [JsonProperty(Required = Required.Default, PropertyName = "KNOWN_PROPERTY", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, NullValueHandling = NullValueHandling.Include)]
        public string KnownProperty { get; private set; }
        // Remainder as before.
    }
