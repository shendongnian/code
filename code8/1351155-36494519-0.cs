    [DataContract]
    public class Field
    {
        [IgnoreDataMember]
        public string Name { get; set; }
        [DataMember]
        public FieldAttributes Attributes { get; set; }
    }
