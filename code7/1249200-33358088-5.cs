    public class ExampleClass
    {
        [JsonSpecifiedProperty("NameSpecified")]
        public string Name { get; set; }
        bool NameSpecified { get { return Name != null; } }
        public int Integer { get; set; }
        [DefaultValue(null)]
        public int? NullInteger { get; set; }
        public DateTime DateTime { get; set; }
        [DefaultValue(null)]
        public DateTime? NullableDateTime { get; set; }
    }
