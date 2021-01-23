    [Serializable]
    [DataContract(Name = "PostContract")]
    public class PostContract
    {
        [DataMember(Name = "k")]
        public string k { get; set; }
        [DataMember(Name = "source")]
        public string source { get; set; }
        [DataMember(Name = "isUrl")]
        public int isUrl { get; set; }
        [DataMember(Name = "ISO2Code")]
        public string ISO2Code { get; set; }
    }
