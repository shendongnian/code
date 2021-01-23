    [DataContract]
    public class ActionMethod
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public List<Parameter> Parameters { get; set; }
        [DataMember]
        public string SupportedHttpMethods { get; set; }
    }
