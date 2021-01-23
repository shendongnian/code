    [DataContract]
    public class PropertyData
    {
        [DataMember(Name="type", EmitDefaultValue=false)]
        public string Type { get; set; }
        [DataMember(Name = "format", EmitDefaultValue = false)]
        public string Format { get; set; }
        [DataMember(Name = "properties", EmitDefaultValue = false)]
        public Dictionary<string, PropertyData> Properties { get; set; }
    }
    [DataContract]
    public class Mappings
    {
        [DataMember(Name = "mappings", EmitDefaultValue = false)]
        public Dictionary<string, PropertyData> DocumentMappings { get; set; }
    }
