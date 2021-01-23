    public class ExampleClass
    {
        [JsonSpecifiedProperty("NameSpecified")]
        public string Name { get; set; }
        bool NameSpecified { get { return Name != null; } }
        [DefaultValue(null)]
        public int? NullInteger { get; set; }
        [DefaultValue(null)]
        public DateTime? NullableDateTime { get; set; }
    }
