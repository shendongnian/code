    [DataContract]
    public class Parameter
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Source { get; set; } //where we pass the parameter when calling the action
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public List<Parameter> SubParameters { get; set; }
    }
