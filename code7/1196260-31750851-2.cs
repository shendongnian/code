        public class MyClass
        {
            [JsonIgnore]
            public Guid Property { get; set; }
            [JsonProperty("Property")]
            Guid? NullableProperty { get { return Property == Guid.Empty ? null : (Guid?)Property; } set { Property = (value == null ? Guid.Empty : value.Value); } }
        }
